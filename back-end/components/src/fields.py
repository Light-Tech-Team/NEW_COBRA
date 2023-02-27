from flask_restful import fields

product_resource_fields = {
    'id': fields.Integer,
    'NAME': fields.String,
    'CODE': fields.String,
    #'description': fields.String,
    #'image': fields.String,
    'ID_FAMILY': fields.Integer
    
}

product_family_resource_fields = {
    'id': fields.Integer,
    'nom': fields.String,
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
    'product_id': fields.Integer,
    'PRICE_BUY': fields.Float,
    'quantite': fields.Integer,
    'montant': fields.Float,
}
