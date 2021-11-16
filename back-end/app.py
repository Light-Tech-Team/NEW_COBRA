from models import db
from flask import Flask, render_template, request, redirect, url_for, flash, jsonify
from flask_restful import Resource, Api, reqparse, abort, fields, marshal_with
from models import *
from datetime import datetime


app = Flask(__name__)
api = Api(app)

app.config['SECRET_KEY'] = 'secret'
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///cobra.db'
db.init_app(app)

with app.app_context():
    #db.create_all()
    pass

################################################################################################

prouct_put_args = reqparse.RequestParser()
prouct_put_args.add_argument('nom', type=str, required=True, help='Nom manquant')
prouct_put_args.add_argument('prix', type=float, required=True, help='Prix manquant')
prouct_put_args.add_argument('description', type=str, required=True, help='Description manquante')
prouct_put_args.add_argument('image', type=str, required=True, help='Image manquante')
prouct_put_args.add_argument('prouct_family_id', type=int, required=True, help='Id famille manquant')

product_update_args = reqparse.RequestParser()
product_update_args.add_argument('nom', type=str, required=False, help='Nom manquant')
product_update_args.add_argument('prix', type=float, required=False, help='Prix manquant')
product_update_args.add_argument('description', type=str, required=False, help='Description manquante')
product_update_args.add_argument('image', type=str, required=False, help='Image manquante')
product_update_args.add_argument('prouct_family_id', type=int, required=False, help='Id famille manquant')

################################################################################################

product_family_put_args = reqparse.RequestParser()
product_family_put_args.add_argument('nom', type=str, required=True, help='Nom de la famille de produit')
product_family_put_args.add_argument('description', type=str, required=True, help='Description de la famille de produit')


product_family_update_args = reqparse.RequestParser()
product_family_update_args.add_argument('nom', type=str, required=False, help='Nom de la famille de produit')
product_family_update_args.add_argument('description', type=str, required=False, help='Description de la famille de produit')

################################################################################################

facture_put_args = reqparse.RequestParser()
facture_put_args.add_argument('date', type=str, required=True, help='Date manquante')
facture_put_args.add_argument('montant', type=float, required=True, help='Montant manquant')
facture_put_args.add_argument('client_id', type=str, required=True, help='client manquant')

facture_update_args = reqparse.RequestParser()
facture_update_args.add_argument('date', type=str, required=False, help='Date manquante')
facture_update_args.add_argument('montant', type=float, required=False, help='Montant manquant')
facture_update_args.add_argument('client_id', type=str, required=False, help='client manquant')

################################################################################################

facture_product_put_args = reqparse.RequestParser()
facture_product_put_args.add_argument('quantite', type=int, required=True, help='Quantite manquante')
facture_product_put_args.add_argument('facture_id', type=int, required=True, help='Id facture manquant')
facture_product_put_args.add_argument('product_id', type=int, required=True, help='Id produit manquant')
facture_product_put_args.add_argument('prix_unitaire', type=float, required=True, help='Prix manquant')

facture_product_update_args = reqparse.RequestParser()
facture_product_update_args.add_argument('quantite', type=int, required=False, help='Quantite manquante')
facture_product_update_args.add_argument('facture_id', type=int, required=False, help='Id facture manquant')
facture_product_update_args.add_argument('product_id', type=int, required=False, help='Id produit manquant')
facture_product_update_args.add_argument('prix_unitaire', type=float, required=False, help='Prix manquant')
################################################################################################

product_resource_fields = {
    'id': fields.Integer,
    'nom': fields.String,
    'prix': fields.Float,
    'description': fields.String,
    'image': fields.String,
    'prouct_family_id': fields.Integer
}

product_family_resource_fields = {
    'id': fields.Integer,
    'nom': fields.String,
    'description': fields.String,
}

facture_resource_fields = {
    'id': fields.Integer,
    'date': fields.String,
    'montant': fields.Float,
    'client_id': fields.String,
}

facture_product_resource_fields = {
    'id': fields.Integer,
    'quantite': fields.Integer,
    'facture_id': fields.Integer,
    'product_id': fields.Integer,
    'prix_unitaire': fields.Float,
}


class ProductFamilyResource(Resource):
    @marshal_with(product_family_resource_fields)
    def get(self, family_id):
        product_family = Prouct_family.query.filter_by(id=family_id).first()
        return product_family


    @marshal_with(product_family_resource_fields)
    def post(self, family_id):
        pass

    @marshal_with(product_family_resource_fields)
    def put(self, family_id):
        args = product_family_update_args.parse_args()
        result = Prouct_family.query.filter_by(id=family_id).first()
        if result:
            abort(404, message="Cette famille de produit existe déjà")
        product_family = Prouct_family(id = family_id, nom=args['nom'], description=args['description'])
        db.session.add(product_family)
        db.session.commit()
        return product_family, 201
        

    @marshal_with(product_family_resource_fields)
    def patch(self, family_id):
        args = product_family_update_args.parse_args()
        product_family = Prouct_family.query.filter_by(id=family_id).first()
        if args['nom']:
            product_family.nom = args['nom']
        if args['description']:
            product_family.description = args['description']
            db.session.commit()
            return product_family, 201
        else:
            abort(404, message="Cette famille de produit n'existe pas")


    def delete(self, family_id):
        product_family = Prouct_family.query.filter_by(id=family_id).first()
        db.session.delete(product_family)
        db.session.commit()
        return '', 204



class product(Resource):
    @marshal_with(product_resource_fields)
    def post(self, product_id):
        args = prouct_put_args.parse_args()
        result = Product.query.filter_by(id=product_id).first()
        if result:
            abort(404, message="Ce produit existe déjà")
        product = Product(id = product_id, nom=args['nom'], prix=args['prix'], description=args['description'], image=args['image'], prouct_family_id=args['prouct_family_id'])
        db.session.add(product)
        db.session.commit()
        return product, 201


    @marshal_with(product_resource_fields)
    def get(self, product_id):
        print(product_id)
        product = Product.query.filter_by(id=product_id).all()
        print(product)
        return product, 201

    
    @marshal_with(product_resource_fields)
    def put(self, product_id):
        args = product_update_args.parse_args()
        result = Product.query.filter_by(id=product_id).first()
        if result:
            abort(404, message="Produit {} inexistant".format(product_id))
        product = Product(id = product_id, nom = args['nom'], prix = args['prix'], description = args['description'], image = args['image'], prouct_family_id = args['prouct_family_id'])
        db.session.add(product)
        db.session.commit()
        return product, 201


    @marshal_with(product_resource_fields)
    def delete(self, product_id):
        product = Product.query.filter_by(id=product_id).first()
        if product:
            db.session.delete(product)
            db.session.commit()
    
class find_froduct_by_family(Resource):
    def find_family_id(self, family_name):
        family = Prouct_family.query.filter_by(nom=family_name).first()
        return int(family.id)

    @marshal_with(product_resource_fields)
    def get(self, family_name):
        product = Product.query.filter_by(prouct_family_id=self.find_family_id(family_name)).all()
        return product






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


class Facture_product_all(Resource):
    @marshal_with(facture_product_resource_fields)
    def get(self):
        facture_product = Facture_product.query.all()
        return facture_product

class FactureResource_all(Resource):
    @marshal_with(facture_resource_fields)
    def get(self):
        facture = Facture.query.all()
        return facture




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

api.add_resource(product, '/product/<int:product_id>')
api.add_resource(ProductFamilyResource, '/product_family/<int:family_id>')
api.add_resource(find_froduct_by_family, '/product/find_by_family/<string:family_name>')
api.add_resource(FactureResource_all, '/facture')
api.add_resource(FactureResource, '/facture/<int:facture_id>')
api.add_resource(Facture_product_all, '/facture_product')
api.add_resource(Facture_products, '/facture_product/<int:facture_product_id>')



if __name__ == '__main__':
    app.run(debug=True)