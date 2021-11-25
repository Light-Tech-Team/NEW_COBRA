from extensions import db

class Facture(db.Model):
    __tablename__ = 'facture'
    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.DateTime)
    montant = db.Column(db.Float)
    client_id = db.Column(db.Integer, db.ForeignKey('client.id'))
    client = db.relationship('Client', backref=db.backref('factures', lazy='select'))



    def __repr__(self):
        return '<Facture %r>' % self.id


class Client(db.Model):
    __tablename__ = 'client'
    id = db.Column(db.Integer, primary_key=True)
    nom = db.Column(db.String(255))
    prenom = db.Column(db.String(255))
    adresse = db.Column(db.String(255))
    #code_postal = db.Column(db.String(255))
    #ville = db.Column(db.String(255))
    #pays = db.Column(db.String(255))
    telephone = db.Column(db.String(255))
    email = db.Column(db.String(255))

    def __repr__(self):
        return '<Client %r>' % self.id


class Facture_product(db.Model):
    __tablename__ = 'facture_product'
    id = db.Column(db.Integer, primary_key=True)
    facture_id = db.Column(db.Integer, db.ForeignKey('facture.id'))
    facture = db.relationship('Facture', backref=db.backref('facture_products', lazy='select'))
    product_id = db.Column(db.Integer, db.ForeignKey('product.id'))
    product = db.relationship('Product', backref=db.backref('facture_products', lazy='select'))
    quantite = db.Column(db.Integer)
    prix_unitaire = db.Column(db.Float)

    def __repr__(self):
        return '<Facture_product %r>' % self.id


class Prouct_family(db.Model):
    __tablename__ = 'prouct_family'
    id = db.Column(db.Integer, primary_key=True)
    nom = db.Column(db.String(255))
    description = db.Column(db.String(255))
    products = db.relationship('Product', backref=db.backref('prouct_family', lazy='select'))
    def __repr__(self):
        return '<Prouct_family %r>' % self.id

class Product(db.Model):
    __tablename__ = 'product'
    id = db.Column(db.Integer, primary_key=True)
    nom = db.Column(db.String(255))
    prix = db.Column(db.Float)
    description = db.Column(db.String(255))
    image = db.Column(db.String(255))
    prouct_family_id = db.Column(db.Integer, db.ForeignKey('prouct_family.id'))


    def __repr__(self):
        return '<Product %r>' % self.id