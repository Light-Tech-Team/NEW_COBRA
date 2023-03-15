from models import db
from extensions import *

db.init_app(app)

with app.app_context():
    #db.create_all()
    pass

from components.product import *
from components.FactureResource_all import *

api.add_resource(family , '/family')
api.add_resource(product, '/product/<int:product_id>')
api.add_resource(ProductResource , '/product')
api.add_resource(FactureResource_all, '/facture')
api.add_resource(Facture_products_id,  '/facture/<int:facture_id>')
api.add_resource(Facture_products_ids, '/facture/<int:facture_id>/<int:facture_element_id>')

if __name__ == '__main__':
    app.run(debug=True)