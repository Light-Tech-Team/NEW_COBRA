from flask_restful import Resource, marshal_with, abort
from .src.args import product_put_args, product_update_args
from .src.fields import product_resource_fields
from extensions import db
from models import Product
class product(Resource):
    
    @marshal_with(product_resource_fields)
    def post(self, product_id):
        args = product_put_args.parse_args()
        result = Product.query.filter_by(id=product_id).first()
        if result:
            abort(404, message="Ce produit existe déjà")
        product = Product(id = product_id, **args)
        db.session.add(product)
        db.session.commit()
        return product, 201


    @marshal_with(product_resource_fields)
    def get(self, product_id):
        print(product_id)
        product = Product.query.filter_by(id=product_id).all()
        print(product)
        return product, 201

    
    @marshal_with(product_resource_fields)
    def put(self, product_id):
        args = product_update_args.parse_args()
        result = Product.query.filter_by(id=product_id).first()
        if result:
            abort(404, message="Produit {} inexistant".format(product_id))
        print(args)
        product = Product(id = product_id, **args)
        db.session.add(product)
        db.session.commit()
        return product, 201
    

    @marshal_with(product_resource_fields)
    def delete(self, product_id):
        product = Product.query.filter_by(id=product_id).first()
        if product:
            db.session.delete(product)
            db.session.commit()