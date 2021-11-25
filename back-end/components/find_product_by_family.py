from flask_restful import Resource, marshal_with
from .src.fields import product_resource_fields
from extensions import db
from models import Product, Prouct_family

class find_product_by_family(Resource):
    def find_family_id(self, family_name):
        family = Prouct_family.query.filter_by(nom=family_name).first()
        return int(family.id)

    @marshal_with(product_resource_fields)
    def get(self, family_name):
        product = Product.query.filter_by(prouct_family_id=self.find_family_id(family_name)).all()
        return product
