from flask_restful import Resource, marshal_with
from .src.args import facture_product_put_args
from .src.fields import facture_product_resource_fields
from models import db


class Facture_product_resource(Resource):
    @marshal_with(facture_product_resource_fields)
    def get(self, facture_product_id):
        facture_product = Facture_product.query.filter_by(id=facture_product_id).first()
        return facture_product

    @marshal_with(facture_product_resource_fields)
    def get_all(self):
        facture_product = Facture_product.query.all()
        return facture_product

    @marshal_with(facture_product_resource_fields)
    def post(self, facture_product_id):
        args = facture_product_put_args.parse_args()
        facture_product = Facture_product(id = facture_product_id, facture_id=args['facture_id'], product_id=args['product_id'], quantite=args['quantite'], prix_unitaire=args['prix_unitaire'])
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
            if args['prix_unitaire']:
                facture_product.prix_unitaire = args['prix_unitaire']
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
