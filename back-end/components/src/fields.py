from flask_restful import fields

product_resource_fields = {
    'id': fields.Integer,
    'NAME': fields.String,
    'CODE': fields.String,
    #'description': fields.String,
    #'image': fields.String,
    'family': fields.String
    
}

product_family_resource_fields = {
    'id': fields.Integer,
    'family': fields.String,
    #'description': fields.String,
}

facture_resource_fields = {
    'id': fields.Integer,
    'date': fields.String,
    'montant': fields.Float,
    #'client_id': fields.String,
}

facture_element_resource_fields = {
    'facture_id': fields.Integer,
    'id': fields.Integer,
    'NAME': fields.String,
    'CODE': fields.String,
    'PRICE_BUY': fields.Float,
    'family':fields.String,
    'quantite': fields.Integer,
    'montant': fields.Float,
}
