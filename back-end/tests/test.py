import requests

BASE_URL = 'http://127.0.0.1:5000/'



products =[
    {
        'nom': 'microCobra1',
        'prix': 1,
        'product_family_id': 0,
        'code': 'microCobra1c', 
        'buy_prix': 1500,
        'sell_prix': 2000

    },
    {
        'nom': 'fridgeCobra2',
        'prix': 2,
        'product_family_id': 1,
        'code': 'fridgeCobra2c',
        'buy_prix': 2000,
        'sell_prix': 2500
    },
    {
        'nom': 'microCobra3',
        'prix': 3,
        'product_family_id': 0,
        'code': 'microCobra3c',
        'buy_prix': 1600,
        'sell_prix': 2100
    },
    {
        'nom': 'TVCobra4',
        'prix': 4,
        'product_family_id': 2,
        'code': 'TVCobra4c',
        'buy_prix': 2500,
        'sell_prix': 3000
    },
    {
        'nom': 'TVCobra5',
        'prix': 5,
        'product_family_id': 2,
        'code': 'TVCobra5c',
        'buy_prix': 2600,
        'sell_prix': 3100
    }
]


product_families = [
    {
        'nom': 'microwave'
    },
    {
        'nom': 'fridge'
    },
    {
        'nom': 'TV'
    }
]


Factures = [{
        'date': '2019-01-01',
        'montant': '1000'
    },
    {
        'date': '2019-02-01',
        'montant': '2000'
    },
    {
        'date': '2019-03-01',
        'montant': '3000'
    },
    {
        'date': '2019-04-01',
        'montant': '4000'
    },
    {
        'date': '2019-05-01',
        'montant': '5000'
    },
    {
        'date': '2019-06-01',
        'montant': '6000'
    },
    {
        'date': '2019-07-01',
        'montant': '7000'
    },
    {
        'date': '2019-08-01',
        'montant': '8000'
    },
    {
        'date': '2019-09-01',
        'montant': '9000'
    },
    {
        'date': '2019-10-01',
        'montant': '10000'
    },
    {
        'date': '2019-11-01',
        'montant': '11000'
    },
    {
        'date': '2019-12-01',
        'montant': '12000'
}]


Facture_products = [
    {
        'facture_id': 0,
        'product_id': 0,
        'quantite': 3,
        'montant': 20
    },
    {
        'facture_id': 0,
        'product_id': 1,
        'quantite': 2,
        'montant': 10
    },
    {
        'facture_id': 0,
        'product_id': 2,
        'quantite': 1,
        'montant': 50
    },
    {
        'facture_id': 0,
        'product_id': 3,
        'quantite': 11,
        'montant': 15
    },
    {
        'facture_id': 1,
        'product_id': 4,
        'quantite': 5,
        'montant': 5
    },
    {
        'facture_id': 1,
        'product_id': 5,
        'quantite': 6,
        'montant': 6
    },
    {
        'facture_id': 2,
        'product_id': 6,
        'quantite': 7,
        'montant': 7
    },
    {
        'facture_id': 2,
        'product_id': 7,
        'quantite': 8,
        'montant': 8
    },
    {
        'facture_id': 2,
        'product_id': 8,
        'quantite': 9,
        'montant': 9
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
    response = requests.post(BASE_URL + 'facture/'+str(i), json=Factures[i])
    #print(i)
    response = requests.get(BASE_URL + 'facture/'+str(i))
    print(response.json())

for i in range(len(Facture_products)):
    response = requests.post(BASE_URL + 'facture_product/'+str(i), json=Facture_products[i])
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
        'montant': 20
    }

#response = requests.post(BASE_URL + 'facture_product/14', json=fac_prod)
