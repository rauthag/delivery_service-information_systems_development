
CREATE TABLE address (
    addressid INTEGER NOT NULL,
    city    VARCHAR(20),
    street  VARCHAR(20)
);


ALTER TABLE address ADD CONSTRAINT address_pk PRIMARY KEY ( addressid );



CREATE TABLE product (
    productid      INTEGER NOT NULL,
    productname    VARCHAR(50),
    productprice   DECIMAL(10, 2) NOT NULL,
    productweight  DECIMAL(10, 2)
);

ALTER TABLE product ADD CONSTRAINT product_pk PRIMARY KEY ( productid );




CREATE TABLE person (
    personid     INTEGER NOT NULL,
    firstname    VARCHAR(30) NOT NULL,
    lastname     VARCHAR(30) NOT NULL,
    birthday     DATE NOT NULL,
    phonenumber  VARCHAR(15) NOT NULL,
    email        VARCHAR(30) NOT NULL,
    gender       VARCHAR(5),
    addressid    INTEGER NOT NULL
);

ALTER TABLE person ADD CONSTRAINT person_pk PRIMARY KEY ( personid );

ALTER TABLE person ADD CONSTRAINT person__un UNIQUE ( email,
                                                      phonenumber );

ALTER TABLE person
ALTER COLUMN birthday DATE NULL;


ALTER TABLE person
    ADD CONSTRAINT person_address_fk FOREIGN KEY ( addressid )
        REFERENCES address ( addressid );

        
   
   
        

CREATE TABLE "user" (
    userid      INTEGER NOT NULL,
    login       VARCHAR(25) NOT NULL,
    "type"      VARCHAR(15) NOT NULL,
    personid    INTEGER NOT NULL
);

ALTER TABLE "user" ADD CONSTRAINT user_pk PRIMARY KEY ( userid );

ALTER TABLE "user" ADD CONSTRAINT user__un UNIQUE ( login );

ALTER TABLE "user"
    ADD CONSTRAINT user_person_fk FOREIGN KEY ( personid )
        REFERENCES person ( personid );


        




CREATE TABLE "storage" (
    storageid    INTEGER NOT NULL,
    "name"       VARCHAR(30) NOT NULL,
    "type"       VARCHAR(15) NOT NULL,
    "capacity"   INTEGER NOT NULL,
    userid       INTEGER NOT NULL,
    addressid    INTEGER NOT NULL
);

ALTER TABLE "storage" ADD CONSTRAINT storage_pk PRIMARY KEY ( storageid );

ALTER TABLE "storage"
    ADD CONSTRAINT storage_address_fk FOREIGN KEY ( addressid )
        REFERENCES address ( addressid );

ALTER TABLE "storage"
    ADD CONSTRAINT storage_user_fk FOREIGN KEY ( userid )
        REFERENCES "user" ( userid );   




CREATE TABLE shipment (
    shipmentid        INTEGER NOT NULL,
    "type"            VARCHAR(40) NOT NULL,
    price             DECIMAL(10, 2) NOT NULL,
    deliveryprice     DECIMAL(10, 2) NOT NULL,
    weight            DECIMAL(7, 2) NOT NULL,
    ordertime         DATE NOT NULL,
    deliveryTime      DATE NOT NULL,
    isconfirmed       CHAR(1) NOT NULL,
    customerid        INTEGER NOT NULL,
    sellerstorageid   INTEGER NOT NULL,
    receivestorageid  INTEGER NOT NULL
);


ALTER TABLE shipment ADD CONSTRAINT shipment_pk PRIMARY KEY ( shipmentid );

ALTER TABLE shipment
    ADD CONSTRAINT shipment_person_fk FOREIGN KEY ( customerid )
        REFERENCES person ( personid );

ALTER TABLE shipment
    ADD CONSTRAINT shipment_receivestorage_fk FOREIGN KEY ( receivestorageid )
        REFERENCES "storage" ( storageid );

ALTER TABLE shipment
    ADD CONSTRAINT shipment_sellerstorage_fk FOREIGN KEY ( sellerstorageid )
        REFERENCES "storage" ( storageid );
        
        

CREATE TABLE shipmentproduct (
    productid   INTEGER NOT NULL,
    shipmentid  INTEGER NOT NULL,
    pieces INTEGER NOT NULL
);

ALTER TABLE shipmentproduct ADD CONSTRAINT shipmentproduct_pk PRIMARY KEY ( productid,
                                                                            shipmentid );

ALTER TABLE shipmentproduct
    ADD CONSTRAINT shipmentproduct_product_fk FOREIGN KEY ( productid )
        REFERENCES product ( productid );

ALTER TABLE shipmentproduct
    ADD CONSTRAINT shipmentproduct_shipment_fk FOREIGN KEY ( shipmentid )
        REFERENCES shipment ( shipmentid );
        
        

CREATE TABLE shipmentmovement (
    shipmentid  INTEGER NOT NULL,
    "state"     VARCHAR(50),
    courierid   INTEGER DEFAULT NULL
);

ALTER TABLE shipmentmovement ADD CONSTRAINT shipmentmovement_pk PRIMARY KEY ( shipmentid );

ALTER TABLE shipmentmovement
    ADD CONSTRAINT shipmentmovement_shipment_fk FOREIGN KEY ( shipmentid )
        REFERENCES shipment ( shipmentid );
        

ALTER TABLE shipmentmovement
    ADD CONSTRAINT shipmentmovement_user_fk FOREIGN KEY ( courierid )
        REFERENCES "user" ( userid );


        
CREATE TABLE shipmenthistory (
    historyid  INTEGER NOT NULL,
    dateandtime        DATE NOT NULL,
    "state"             VARCHAR(20) NOT NULL,
    shipmentid         INTEGER NOT NULL
);

ALTER TABLE shipmenthistory ADD CONSTRAINT shipmenthistory_pk PRIMARY KEY ( historyid );


ALTER TABLE shipmenthistory
    ADD CONSTRAINT shipmenthistory_shipmentmovement_fk FOREIGN KEY ( shipmentid )
        REFERENCES shipmentmovement ( shipmentid );
        

        
CREATE TABLE "notification" (
    notificationID INTEGER NOT NULL,
	"date" DATE NOT NULL,
	notificationText VARCHAR(100) NOT NULL,
	customerid INTEGER NOT NULL
);

ALTER TABLE "notification" ADD CONSTRAINT notificationid_pk PRIMARY KEY (notificationid);

ALTER TABLE "notification"
    ADD CONSTRAINT notification_person_fk FOREIGN KEY ( customerid )
        REFERENCES person ( personid );

