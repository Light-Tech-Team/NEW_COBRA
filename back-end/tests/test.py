import requests

BASE_URL = 'http://127.0.0.1:5000/'



products =[
    {
        'nom': 'microCobra1',
        'prix': '1',
        'description': 'Cobra1',
        'image': 'Cobra1',
        'prouct_family_id': 0
    },
    {
        'nom': 'fridgeCobra2',
        'prix': '2',
        'description': 'Cobra2',
        'image': 'Cobra2',
        'prouct_family_id': 1
    },
    {
        'nom': 'microCobra3',
        'prix': '3',
        'description': 'Cobra3',
        'image': 'Cobra3',
        'prouct_family_id': 0
    },
    {
        'nom': 'TVCobra4',
        'prix': '4',
        'description': 'Cobra4',
        'image': 'Cobra4',
        'prouct_family_id': 2
    },
    {
        'nom': 'TVCobra5',
        'prix': '5',
        'description': 'Cobra5',
        'image': 'Cobra5',
        'prouct_family_id': 2
    }
]


product_families = [
    {
        'nom': 'microwave',
        'description': 'heat food'
    },
    {
        'nom': 'fridge',
        'description': 'cool food'
    },
    {
        'nom': 'TV',
        'description': 'see food'
    }
]


Factures = [{
        'date': '2019-01-01',
        'montant': '1000',
        'client_id': 0
    },
    {
        'date': '2019-02-01',
        'montant': '2000',
        'client_id': 0
    },
    {
        'date': '2019-03-01',
        'montant': '3000',
        'client_id': 0
    },
    {
        'date': '2019-04-01',
        'montant': '4000',
        'client_id': 0
    },
    {
        'date': '2019-05-01',
        'montant': '5000',
        'client_id': 0
    },
    {
        'date': '2019-06-01',
        'montant': '6000',
        'client_id': 0
    },
    {
        'date': '2019-07-01',
        'montant': '7000',
        'client_id': 0
    },
    {
        'date': '2019-08-01',
        'montant': '8000',
        'client_id': 0
    },
    {
        'date': '2019-09-01',
        'montant': '9000',
        'client_id': 0
    },
    {
        'date': '2019-10-01',
        'montant': '10000',
        'client_id': 0
    },
    {
        'date': '2019-11-01',
        'montant': '11000',
        'client_id': 1
    },
    {
        'date': '2019-12-01',
        'montant': '12000',
        'client_id': 1
}]


Facture_products = [
    {
        'facture_id': 0,
        'product_id': 0,
        'quantite': 3,
        'prix_unitaire': 20
    },
    {
        'facture_id': 0,
        'product_id': 1,
        'quantite': 2,
        'prix_unitaire': 10
    },
    {
        'facture_id': 0,
        'product_id': 2,
        'quantite': 1,
        'prix_unitaire': 50
    },
    {
        'facture_id': 0,
        'product_id': 3,
        'quantite': 11,
        'prix_unitaire': 15
    },
    {
        'facture_id': 1,
        'product_id': 4,
        'quantite': 5,
        'prix_unitaire': 5
    },
    {
        'facture_id': 1,
        'product_id': 5,
        'quantite': 6,
        'prix_unitaire': 6
    },
    {
        'facture_id': 2,
        'product_id': 6,
        'quantite': 7,
        'prix_unitaire': 7
    },
    {
        'facture_id': 2,
        'product_id': 7,
        'quantite': 8,
        'prix_unitaire': 8
    },
    {
        'facture_id': 2,
        'product_id': 8,
        'quantite': 9,
        'prix_unitaire': 9
    }]


for i in range(len(products)):
    #response = requests.put(BASE_URL + 'product/'+str(i), json=products[i])
    response = requests.get(BASE_URL + 'product/'+str(i))
    print(response.json())


for i in range(len(product_families)):
    #response = requests.put(BASE_URL + 'product_family/'+str(i), json=product_families[i])
    #print(i)
    response = requests.get(BASE_URL + 'product_family/'+str(i))
    print(response.json())


for i in range(len(Factures)):
    #response = requests.post(BASE_URL + 'facture/'+str(i), json=Factures[i])
    #print(i)
    response = requests.get(BASE_URL + 'facture/'+str(i))
    print(response.json())

for i in range(len(Facture_products)):
    #response = requests.post(BASE_URL + 'facture_product/'+str(i), json=Facture_products[i])
    #print(i)
    response = requests.get(BASE_URL + 'facture_product/'+str(i))
    print(response.json())


response = requests.get(BASE_URL + "product_family/2")
print(response.json())
response = requests.get(BASE_URL + "/product/find_by_family/TV")
print(response.json())


fac_prod=     {
        'facture_id': 0,
        'product_id': 0,
        'quantite': 3,
        'prix_unitaire': 20
    }

response = requests.post(BASE_URL + 'facture_product/11', json=fac_prod)
