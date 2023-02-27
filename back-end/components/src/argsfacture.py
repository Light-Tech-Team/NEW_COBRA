from flask_restful import  reqparse

facture_element_put_args = reqparse.RequestParser()
facture_element_put_args.add_argument('quantite', type=int, required=True, help='Quantite manquante')
facture_element_put_args.add_argument('facture_id', type=int, required=True, help='Id facture manquant')
facture_element_put_args.add_argument('product_id', type=int, required=True, help='Id produit manquant')
facture_element_put_args.add_argument('montant', type=float, required=True, help='Montant manquant')



facture_element_update_args = reqparse.RequestParser()
facture_element_update_args.add_argument('quantite', type=int, required=False, help='Quantite manquante')
facture_element_update_args.add_argument('facture_id', type=int, required=False, help='Id facture manquant')
facture_element_update_args.add_argument('product_id', type=int, required=False, help='Id produit manquant')
facture_element_update_args.add_argument('montant', type=float, required=False, help='montant manquant')
################################################################################################
