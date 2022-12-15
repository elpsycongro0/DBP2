from flask import Flask, render_template, request
import sqlite3
from flask import g
import os
from werkzeug.utils import secure_filename

import aiohttp
import asyncio
import requests as rq
import numpy as np
import cv2

app = Flask(__name__)

PROJECT_ROOT = os.path.dirname(os.path.realpath(__file__))
DATABASE = os.path.join(PROJECT_ROOT, 'test.db')

def get_db():
  print(DATABASE)
  db = getattr(g, '_database', None)
  if db is None:
    db = g._database = sqlite3.connect(DATABASE)
  return db

@app.teardown_appcontext
def close_connection(exception):
  db = getattr(g, '_database', None)
  if db is not None:
    db.close()

@app.route("/create_tables", methods=["GET"])
def create_tables():
  cur = get_db().cursor()
  cur.execute("CREATE TABLE IF NOT EXISTS frames(frame, classname, x1, y1, x2, y2)")
  return "created table"

def insert_frame_entry(file_name, class_name, x1, y1, x2, y2):
  cur = get_db().cursor()
  cur.execute(f"""
    INSERT INTO frames VALUES
        ('{file_name}', '{class_name}', {x1}, {y1}, {x2}, {y2})
    """)
  get_db().commit()
async def main():
    async with aiohttp.ClientSession() as session:
        async with session.get('http://httpbin.org/get') as resp:
            print(resp.status)
            print(await resp.text())

def get_images(seach_key = ""):
  cur = get_db().cursor()
  res = None
  if(seach_key == ""):
    res = cur.execute("SELECT * FROM frames")
  else:
    res = cur.execute(f"SELECT * FROM frames where classname=\"{seach_key}\"")
  
  return res.fetchall()

@app.route("/handle_detection", methods=["POST"])
def handle_detection():
  cloud_func_url = "https://us-east1-festive-vim-364612.cloudfunctions.net/deteccion-de-imagenes"
  image = request.files["image"]
  # transform file to nmpy array of 300x300x3
  filename = secure_filename(image.filename)
  nparr = np.frombuffer(image.read(), np.uint8)
  img_np = cv2.imdecode(nparr, cv2.IMREAD_COLOR )
  resized_image = cv2.resize(img_np, dsize=(300, 300), interpolation=cv2.INTER_CUBIC)

  paramss = {"image_data":resized_image.tolist(), 
          "threshold":float(0.5)}
  print("making post request")
  # request to cloud function
  returntest = rq.post(cloud_func_url, json = paramss)
  # insert into database
  names=['person', 'bicycle', 'car', 'motorcycle', 'airplane', 'bus', 'train', 'truck', 'boat', 'traffic light', 'fire hydrant', 'stop sign', 'parking meter', 'bench', 'bird', 'cat', 'dog', 'horse', 'sheep', 'cow', 'elephant', 'bear', 'zebra', 'giraffe', 'backpack', 'umbrella', 'handbag', 'tie', 'suitcase', 'frisbee', 'skis', 'snowboard', 'sports ball', 'kite', 'baseball bat', 'baseball glove', 'skateboard', 'surfboard', 'tennis racket', 'bottle', 'wine glass', 'cup', 'fork', 'knife', 'spoon', 'bowl', 'banana', 'apple', 'sandwich', 'orange', 'broccoli', 'carrot', 'hot dog', 'pizza', 'donut', 'cake', 'chair', 'couch', 'potted plant', 'bed', 'dining table', 'toilet', 'tv', 'laptop', 'mouse', 'remote', 'keyboard', 'cell phone', 'microwave', 'oven', 'toaster', 'sink', 'refrigerator', 'book', 'clock', 'vase', 'scissors', 'teddy bear', 'hair drier', 'toothbrush']
  data = returntest.json()
  for i in range(len(data['scores'])):
    print(filename+","+names[int(data['classes'][i])-1]+","+str(data['boxes'][i][0])+","+str(data['boxes'][i][1])+","+str(data['boxes'][i][2])+","+str(data['boxes'][i][3])+"\n")
    insert_frame_entry(filename, names[int(data['classes'][i])-1], str(data['boxes'][i][0]), str(data['boxes'][i][1]), str(data['boxes'][i][2]), str(data['boxes'][i][3]))
  #save 
  detected_classes = data["classes"]
  detected_boxes = data["boxes"]
  height, width, channels = img_np.shape
  for i in range(len(detected_classes)):
    img_np = cv2.rectangle(img_np, (int(detected_boxes[i][1]*width),int(detected_boxes[i][0]*height)), (int(detected_boxes[i][3]*width),int(detected_boxes[i][2]*height)), (255,0,0), 1)
  
  image_path = os.path.join(PROJECT_ROOT, "static","images",filename)
  cv2.imwrite(image_path, img_np)
  
  return """
    entry added to database, 
    <a href="{{ url_for('hello_world') }}">
        Refresh
      </a>
  """
  #

@app.route("/search", methods=["GET"])
def search():
  search_key = request.args.get('search_key')
  data = get_images(search_key)
  return render_template("index.html", data=data)

@app.route("/loadcsv", methods=["GET"])
def loadcsv():
  
  # using loadtxt()
  arr = np.loadtxt("labels.txt",
                  delimiter=",", dtype=str)
  # for i in arr:
  #   insert_frame_entry(i[0], i[1], i[2], i[3], i[4], i[5])
  return f"inserted {len(arr)} entries"

@app.route("/")
def hello_world():
  create_tables()
  alldata = get_images()
  return render_template("index.html", data=alldata)