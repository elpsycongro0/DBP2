from flask import Flask, render_template, request

app = Flask(__name__)

@app.route("/")
def hello_world():
    return render_template("index.html")


# @app.route("/<string:name>")
# def name(name):
#     return "<h1>hello {}</h1>".format(name)

@app.route("/hello", methods=["POST"])
def hello():
    datos = {
        "name" : request.form.get("name"),
        "birth" : request.form.get("birth"),
        "mail" : request.form.get("mail"),
        "nacionality" : request.form.get("nacionality"),
        "engLvl" : request.form.get("engLvl"),
        "lang" : request.form.getlist("lang"),
        "aptitudes" : request.form.get("aptitudes"),
        "habilidades" : request.form.getlist("habilidades"),
        "perfil" : request.form.get("perfil")
    }
    return render_template("cv.html", datos = datos)
 