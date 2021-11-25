from flask_restful import Resource, marshal_with, abort
from .src.args import facture_product_put_args, facture_product_update_args
from .src.fields import facture_product_resource_fields
from extensions import db
from models import Facture_product


class Facture_products(Resource):
    @marshal_with(facture_product_resource_fields)
    def get(self, facture_product_id):
        facture_product = Facture_product.query.filter_by(id=facture_product_id).first()
        return facture_product , 200
    
    @marshal_with(facture_product_resource_fields)
    def get_all(self):
        facture_product = Facture_product.query.all()
        return facture_product, 200
    
    @marshal_with(facture_product_resource_fields)
    def post(self, facture_product_id):
        args = facture_product_put_args.parse_args()
        print(args)
        facture_product = Facture_product(id = facture_product_id, **args)
        db.session.add(facture_product)
        db.session.commit()
        return facture_product, 201

    @marshal_with(facture_product_resource_fields)
    def put(self, facture_product_id):
        args = facture_product_update_args.parse_args()
        facture_product = Facture_product.query.filter_by(id=facture_product_id).first()
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
    
    def delete(self, facture_product_id):
        facture_product = Facture_product.query.filter_by(id=facture_product_id).first()
        if facture_product:
            db.session.delete(facture_product)
            db.session.commit()
        else:
            abort(404, message="Ce produit n'existe pas")
