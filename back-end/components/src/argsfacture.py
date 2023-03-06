from flask_restful import  reqparse
from cerberus import Validator
import json


facture_element_put_args= reqparse.RequestParser()
def facture_element(value):
    facture_element = {
        'id': {'required': True, 'type': 'integer'},
        'quantite': {'required': True, 'type': 'integer'},
        'facture_id': {'required': True, 'type': 'integer'},
        'PRICE_BUY': {'required': True, 'type': 'float'},
        'product_id': {'required': True, 'type': 'integer'},
        'montant': {'required': True, 'type': 'float'}
    }
    v = Validator(facture_element)
    if v.validate(value):
        return value
    else:
        raise ValueError(json.dumps(v.errors))
    
facture_element_put_args.add_argument('facture', type=facture_element, action='append')


facture_element_update_args = reqparse.RequestParser()
facture_element_update_args.add_argument('quantite', type=int, required=False, help='Quantite manquante')
facture_element_update_args.add_argument('facture_id', type=int, required=False, help='Id facture manquant')
facture_element_update_args.add_argument('product_id', type=int, required=False, help='Id produit manquant')
facture_element_update_args.add_argument('montant', type=float, required=False, help='montant manquant')
################################################################################################
