from models import db
from flask import Flask
from flask_restful import Resource, Api, reqparse, abort, fields, marshal_with
from models import *
from datetime import datetime


from components.ProductFamilyResource import ProductFamilyResource
from components.product import product
from components.FactureResource import FactureResource
from components.find_product_by_family import find_product_by_family
from components.Facture_product_resource import Facture_product_resource
from components.Facture_product_all import Facture_product_all
from components.Facture_products import Facture_products
from components.FactureResource_all import FactureResource_all

app = Flask(__name__)
api = Api(app)

app.config['SECRET_KEY'] = 'secret'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///cobra.db'
db.init_app(app)

with app.app_context():
    #db.create_all()
    pass





api.add_resource(product, '/product/<int:product_id>')
api.add_resource(ProductFamilyResource, '/product_family/<int:family_id>')
api.add_resource(find_product_by_family, '/product/find_by_family/<string:family_name>')
api.add_resource(FactureResource_all, '/facture')
api.add_resource(FactureResource, '/facture/<int:facture_id>')
api.add_resource(Facture_product_all, '/facture_product')
api.add_resource(Facture_products, '/facture_product/<int:facture_product_id>')



if __name__ == '__main__':
    app.run(debug=True)