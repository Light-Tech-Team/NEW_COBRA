from flask_restful import Resource, marshal_with
from .src.fields import facture_product_resource_fields
from models import db



class Facture_product_all(Resource):
    @marshal_with(facture_product_resource_fields)
    def get(self):
        facture_product = Facture_product.query.all()
        return facture_product
