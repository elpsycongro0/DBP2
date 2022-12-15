# Generar cv en pdf y enviar email

3 vistas

- MainPage: formulario dinámico para llenado de datos del currículum

<img src="https://user-images.githubusercontent.com/13887870/207826912-bad699fc-238b-4be3-b85b-fd141ad220a7.jpg" alt="drawing" width="200"/>
<img src="https://user-images.githubusercontent.com/13887870/207826935-d0617611-d523-45fb-a844-01fe3284542b.jpg" alt="drawing" width="200"/>

- Page1: Se muestra la vista del cv con los datos del formulario

Se utiliza el paquete nugget ImageFromXamarinUI, para conseguir un screenshot del grid que muestra el cv

Se utiliza el paquete nugget Syncfusion.Pdf para generar un pdf con la imagen del cv

<img src="https://user-images.githubusercontent.com/13887870/207826939-91b54c3f-39b5-478c-a9f6-0a81436d698a.jpg" alt="drawing" width="200"/>

- pdfView: Se visualiza el pdf generado y un pequeño form para enviarlo hacia una dirección de correo electrónico

Se usa un SmtpClient con una cuenta de gmail para enviar un correo adjuntando el MemoryStream del pdf generado

<img src="https://user-images.githubusercontent.com/13887870/207826948-1db0a058-8670-4228-9d76-13b12d210e88.jpg" alt="drawing" width="200"/>

El resultado llega correctamente al correo

<img src="https://user-images.githubusercontent.com/13887870/207828411-b560b91f-49da-4412-8c30-3f37d44662fb.jpg" alt="drawing" width="300"/>
<img src="https://user-images.githubusercontent.com/13887870/207828423-265c5990-077e-4084-9a1d-57455867ccda.jpg" alt="drawing" width="300"/>

