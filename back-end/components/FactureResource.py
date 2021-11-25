from flask_restful import Resource, marshal_with, abort
from .src.args import facture_put_args, facture_update_args
from .src.fields import facture_resource_fields
from datetime import datetime

from extensions import db
from models import Facture


class FactureResource(Resource):
    @marshal_with(facture_resource_fields)
    def get(self, facture_id):
        facture = Facture.query.filter_by(id=facture_id).first()
        return facture

    def get_all(self):
        facture = Facture.query.all()
        return facture

    @marshal_with(facture_resource_fields)
    def post(self, facture_id):
        print(facture_id)
        args = facture_put_args.parse_args()
        facture = Facture(id = facture_id, date=datetime.strptime(args['date'], '%Y-%d-%m'), montant=args['montant'], client_id=args['client_id'])
        db.session.add(facture)
        db.session.commit()
        return facture, 201
    
    @marshal_with(facture_resource_fields)
    def put(self, facture_id):
        args = facture_update_args.parse_args()
        facture = Facture.query.filter_by(id=facture_id).first()
        if facture:
            if args['date']:
                facture.date = datetime.strptime(args['date'], '%Y-%d-%m')
            if args['montant']:
                facture.montant = args['montant']
            if args['client_id']:
                facture.client_id = args['client_id']
            db.session.commit()
            return facture, 201
        else:
            abort(404, message="Cette facture n'existe pas")
    
    def delete(self, facture_id):
        facture = Facture.query.filter_by(id=facture_id).first()
        if facture:
            db.session.delete(facture)
            db.session.commit()
        else:
            abort(404, message="Cette facture n'existe pas")
    