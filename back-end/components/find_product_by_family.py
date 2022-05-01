from flask_restful import Resource, marshal_with
from .src.fields import product_resource_fields
from extensions import db
from models import Product, Product_family

class find_product_by_family(Resource):
    def find_family_id(self, family_name):
        family = Product_family.query.filter_by(nom=family_name).first()
        return int(family.id) if family else None

    @marshal_with(product_resource_fields)
    def get(self, family_name):
        family_id = self.find_family_id(family_name)
        if family_id:
            products = Product.query.filter_by(ID_FAMILY=family_id).all()
            return products
        else:
            return 404

