from models import db
from extensions import *

db.init_app(app)

with app.app_context():
    #db.create_all()
    pass

from components.ProductFamilyResource import ProductFamilyResource
from components.product import product
from components.find_product_by_family import find_product_by_family
from components.FactureResource_all import *

api.add_resource(product, '/product')
api.add_resource(find_product_by_family, '/product/<int:product_id>')
api.add_resource(ProductFamilyResource, '/family')
api.add_resource(FactureResource_all, '/facture')
api.add_resource(Facture_products_id,  '/facture/<int:facture_id>')
api.add_resource(Facture_products_ids, '/facture/<int:facture_id>/<int:facture_element_id>')

if __name__ == '__main__':
    app.run(debug=True)