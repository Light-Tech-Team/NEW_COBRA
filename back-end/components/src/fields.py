from flask_restful import fields

product_resource_fields = {
    'id': fields.Integer,
    'nom': fields.String,
    'sell_prix': fields.Float,
    'buy_prix': fields.Float,
    #'description': fields.String,
    #'image': fields.String,
    'montant': fields.Float,
    'prouct_family_id': fields.Integer
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

facture_product_resource_fields = {
    'id': fields.Integer,
    'quantite': fields.Integer,
    'facture_id': fields.Integer,
    'product_id': fields.Integer,
    'montant': fields.Float,

}
