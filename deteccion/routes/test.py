# pip install opencv-python
# pip install aiohttp
# pip install nest-asyncio
# pip install aiofiles

# convert video to frames for prediction
# custom framerate 10 is ok
import cv2
import asyncio
import aiohttp  # pip install aiohttp aiodns
import nest_asyncio
import aiofiles
nest_asyncio.apply()

async def worker(
    session: aiohttp.ClientSession,
    queue
) -> dict:
    names=['person', 'bicycle', 'car', 'motorcycle', 'airplane', 'bus', 'train', 'truck', 'boat', 'traffic light', 'fire hydrant', 'stop sign', 'parking meter', 'bench', 'bird', 'cat', 'dog', 'horse', 'sheep', 'cow', 'elephant', 'bear', 'zebra', 'giraffe', 'backpack', 'umbrella', 'handbag', 'tie', 'suitcase', 'frisbee', 'skis', 'snowboard', 'sports ball', 'kite', 'baseball bat', 'baseball glove', 'skateboard', 'surfboard', 'tennis racket', 'bottle', 'wine glass', 'cup', 'fork', 'knife', 'spoon', 'bowl', 'banana', 'apple', 'sandwich', 'orange', 'broccoli', 'carrot', 'hot dog', 'pizza', 'donut', 'cake', 'chair', 'couch', 'potted plant', 'bed', 'dining table', 'toilet', 'tv', 'laptop', 'mouse', 'remote', 'keyboard', 'cell phone', 'microwave', 'oven', 'toaster', 'sink', 'refrigerator', 'book', 'clock', 'vase', 'scissors', 'teddy bear', 'hair drier', 'toothbrush']
    while True:
        # Get a "work item" out of the queue.
        frame = await queue.get()
        json = {"image_data":frame["frame_content"], "threshold":float(0.5)}
        func_url = "https://us-east1-festive-vim-364612.cloudfunctions.net/deteccion-de-imagenes"
        
        # print(completeurl)
        data = None
        async with session.post(url=func_url, json=json) as response:
          data = await response.json()
        print(data)
        print(str(frame["frame_id"]))
        for i in range(len(data['scores'])):
          async with aiofiles.open('labels.txt', mode='a') as f:
            #Int frame Str classname Int x1 Int y1Int x2 Int y2
            await f.write(str(frame["frame_id"])+","+names[int(data['classes'][i])-1]+","+str(data['boxes'][i][0])+","+str(data['boxes'][i][1])+","+str(data['boxes'][i][2])+","+str(data['boxes'][i][3])+"\n")

        queue.task_done()

async def main(video_path):
    
    # Create a queue that we will use to store our "workload".
    queue = asyncio.Queue()
    # Create three worker tasks to process the queue concurrently.
    tasks = []

    session = aiohttp.ClientSession()
    for i in range(50):
        print("creating worker")
        task = asyncio.create_task(worker(session=session, queue=queue))
        tasks.append(task)
    # fill queue 
    print("Loading work queue")
    vidcap = cv2.VideoCapture(video_path)
    success,image = vidcap.read()
    count = 0
    while success: 
      if(vidcap.get(cv2.CAP_PROP_POS_MSEC)>=count*100): #every 100 milliseconds -> 10fps
        resized_image = cv2.resize(image, dsize=(300, 300), interpolation=cv2.INTER_CUBIC)
        #put frame in queue
        print(vidcap.get(cv2.CAP_PROP_POS_FRAMES), " of ", vidcap.get(cv2.CAP_PROP_FRAME_COUNT))
        queue.put_nowait({"frame_id": vidcap.get(cv2.CAP_PROP_POS_FRAMES),"frame_content":resized_image.tolist()})
        count += 1
        # cv2.imwrite(f"{video_path}{count}.jpg", image)
      success,image = vidcap.read()
      # if(vidcap.get(cv2.CAP_PROP_POS_MSEC)>=2*1000): #every 100 milliseconds -> 10fps
      #   success=False
    # Wait until the queue is fully processed.
    await queue.join()
    await session.close()
    # Cancel our worker tasks.
    for task in tasks:
        task.cancel()
    # Wait until all worker tasks are cancelled.
    await asyncio.gather(*tasks, return_exceptions=True)
asyncio.run(main("WeAreGoingOnBullrun.mp4"))