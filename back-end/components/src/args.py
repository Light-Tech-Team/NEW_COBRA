
from flask_restful import  reqparse

################################################################################################

prouct_put_args = reqparse.RequestParser()
prouct_put_args.add_argument('nom', type=str, required=True, help='Nom manquant')
prouct_put_args.add_argument('prix', type=float, required=True, help='Prix manquant')
prouct_put_args.add_argument('description', type=str, required=True, help='Description manquante')
prouct_put_args.add_argument('image', type=str, required=True, help='Image manquante')
prouct_put_args.add_argument('prouct_family_id', type=int, required=True, help='Id famille manquant')

product_update_args = reqparse.RequestParser()
product_update_args.add_argument('gnom', type=str, required=False, help='Nom manquant')
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
