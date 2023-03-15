from flask_restful import Resource, marshal_with, abort
from .src.args import product_put_args, product_update_args,product_family_update_args
from .src.fields import product_resource_fields,product_resource_fields,product_family_resource_fields
from extensions import db
from models import Product, Product_family




class product(Resource):
    
    
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
            
            
            
class family(Resource):
 
    @marshal_with(product_family_resource_fields)
    def get(self):
            family =  Product_family.query.all()
           ## products = Product.query.all()
            return family
    
    
    
class ProductResource(Resource):
    @marshal_with(product_resource_fields)
    def get(self):
        product =  db.session.query(Product.id, Product.NAME, Product.CODE,Product_family.family ). \
            join(Product_family,Product.ID_FAMILY==Product_family.id).all()
        
        return product


    @marshal_with(product_resource_fields)
    def post(self):
        pass


        



           