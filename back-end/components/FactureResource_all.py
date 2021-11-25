from flask_restful import Resource, marshal_with
from .src.fields import facture_resource_fields
from extensions import  db
from models import Facture

class FactureResource_all(Resource):
    @marshal_with(facture_resource_fields)
    def get(self):
        facture = Facture.query.all()
        return facture
