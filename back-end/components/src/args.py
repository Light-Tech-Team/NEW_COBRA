
from flask_restful import  reqparse




################################################################################################
product_post_args = reqparse.RequestParser()
product_post_args.add_argument('NAME', type=str, required=True, help='Nom manquant')
product_post_args.add_argument('CODE', type=str, required=True, help='Code manquant')
product_post_args.add_argument('family', type=str, required=True, help='famille manquant')







product_put_args = reqparse.RequestParser()
product_put_args.add_argument('NAME', type=str, required=True, help='Nom manquant')
#product_put_args.add_argument('PRICE_BUY', type=float, required=True, help='Prix manquant')
product_put_args.add_argument('CODE', type=str, required=True, help='Code manquant')
#product_put_args.add_argument('PRICE_SELL', type=float, required=True, help='Prix manquant')
#product_put_args.add_argument('description', type=str, required=True, help='Description manquante')
#product_put_args.add_argument('image', type=str, required=True, help='Image manquante')
product_put_args.add_argument('ID_FAMILY', type=int, required=True, help='Id famille manquant')

product_update_args = reqparse.RequestParser()
product_update_args.add_argument('NAME', type=str, required=False, help='Nom manquant')
#product_update_args.add_argument('PRICE_BUY', type=float, required=False, help='Prix manquant')
product_update_args.add_argument('CODE', type=str, required=False, help='Code manquant')
#product_update_args.add_argument('PRICE_SELL', type=float, required=False, help='Prix manquant')

#product_update_args.add_argument('description', type=str, required=False, help='Description manquante')
#product_update_args.add_argument('image', type=str, required=False, help='Image manquante')
product_update_args.add_argument('ID_FAMILY', type=int, required=False, help='Id famille manquant')

################################################################################################

product_family_put_args = reqparse.RequestParser()
product_family_put_args.add_argument('nom', type=str, required=True, help='Nom de la famille de produit')
#product_family_put_args.add_argument('description', type=str, required=True, help='Description de la famille de produit')


product_family_update_args = reqparse.RequestParser()
product_family_update_args.add_argument('nom', type=str, required=False, help='Nom de la famille de produit')
#product_family_update_args.add_argument('description', type=str, required=False, help='Description de la famille de produit')

################################################################################################

