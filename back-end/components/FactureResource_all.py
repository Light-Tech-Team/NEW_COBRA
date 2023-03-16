from models import Facture ,Facture_element,Product,Product_family
from .src.argsfacture import facture_element_put_args,facture_element_update_args
from .src.fields import facture_resource_fields,facture_element_resource_fields
from extensions import db
from flask_restful import Resource, marshal_with, abort

class FactureResource_all(Resource):
    @marshal_with(facture_resource_fields)
    def get(self):
        facture = Facture.query.all()
        return facture

    @marshal_with(facture_element_resource_fields)
    def post(self):
    
        args =facture_element_put_args.parse_args()
        for arg in args['facture']:
             product = Product.query.filter_by(NAME=arg['NAME'] ,CODE=arg['CODE']).first()
             if not product :
                print("not found")
             else:
                facture_element = Facture_element(arg['id'],arg['facture_id'],product.id, arg['PRICE_BUY']
                                                  , arg['quantite'],arg['montant'])
                db.session.add(facture_element)
                db.session.commit()
               # facture_element = Facture_element(**arg)
               # print(facture_element.product_id)
      
        return   201
    
    
class Facture_products_ids(Resource):
  
    @marshal_with(facture_element_resource_fields)
    def put(self, facture_id,facture_product_id):
        args = facture_element_update_args.parse_args()
        facture_product = Facture_element.query.filter_by(id=facture_product_id).first()
        if facture_product:
            if args['facture_id']:
                facture_product.facture_id = args['facture_id']
            if args['product_id']:
                facture_product.product_id = args['product_id']
            if args['quantite']:
                facture_product.quantite = args['quantite']
            if args['montant']:
                facture_product.montant = args['montant']
            db.session.commit()
            return facture_product, 201
        else:
            abort(404, message="Ce produit n'existe pas")
    
    @marshal_with(facture_element_resource_fields)
    def delete(self, facture_id,facture_product_id):
        facture_product = Facture_element.query.filter_by(id=facture_product_id).first()
        if facture_product:
            db.session.delete(facture_product)
            db.session.commit()
        else:
            abort(404, message="Ce produit n'existe pas")

class Facture_products_id(Resource):
    @marshal_with(facture_element_resource_fields)
    def get(self, facture_id):
        ##facture_element = Facture_element.query.filter_by(facture_id=facture_id).all()
        facture_element = db.session.query(Facture_element.id,Facture_element.facture_id, Product.NAME, Product.CODE,Product_family.family,
                                          Facture_element.PRICE_BUY,Facture_element.montant,Facture_element.quantite ). \
            filter(facture_id==Facture_element.facture_id) .\
            join(Product,Product.id==Facture_element.product_id).\
            join(Product_family,Product.ID_FAMILY==Product_family.id)
           ## products = Product.query.all()
           ## return products.all()
        
        return facture_element.all() , 200   