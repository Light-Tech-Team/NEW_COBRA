from flask_restful import Resource, marshal_with, fields
from .src.args import product_family_update_args
from .src.fields import product_family_resource_fields
from models import db

class ProductFamilyResource(Resource):
    @marshal_with(product_family_resource_fields)
    def get(self, family_id):
        product_family = Product_family.query.filter_by(id=family_id).first()
        return product_family


    @marshal_with(product_family_resource_fields)
    def post(self, family_id):
        pass

    @marshal_with(product_family_resource_fields)
    def put(self, family_id):
        args = product_family_update_args.parse_args()
        result = Product_family.query.filter_by(id=family_id).first()
        if result:
            abort(404, message="Cette famille de produit existe déjà")
        product_family = Product_family(id = family_id, nom=args['nom'], description=args['description'])
        db.session.add(product_family)
        db.session.commit()
        return product_family, 201
        

    @marshal_with(product_family_resource_fields)
    def patch(self, family_id):
        args = product_family_update_args.parse_args()
        product_family = Product_family.query.filter_by(id=family_id).first()
        if args['nom']:
            product_family.nom = args['nom']
        if args['description']:
            product_family.description = args['description']
            db.session.commit()
            return product_family, 201
        else:
            abort(404, message="Cette famille de produit n'existe pas")


    def delete(self, family_id):
        product_family = Product_family.query.filter_by(id=family_id).first()
        db.session.delete(product_family)
        db.session.commit()
        return '', 204