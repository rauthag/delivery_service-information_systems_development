            /***3.3 Vloženie novej zásielky a automatická aktualizácia cien a váhy***/
            Console.WriteLine("(3.3)Adding new shipment...");
            Person p2 = new Person("Neregistrovaný", "Užívateľ", "1996-10-12", "+421" + RandomString("number", 9),
                       RandomString("word", 5) + "@email.com", "muz", a1, a1.Id);
            PersonTable.Insert(p2);
            p2.Id = PersonTable.SelectMaxId(db);

            string productIds = "4,5,6"; /* ID produtkov, ktoré si užívateľ vyberie v rozhraní*/;
            String CreateAndUpdateResult = ShipmentTable.CreateAndUpdateShipment("Test funkcie 3.3.-", p2.Id, 1, 4, 2,productIds, db);
            Console.WriteLine(CreateAndUpdateResult);
            Console.WriteLine(" ");

            /***3.4 Automatická aktualizácia ceny doručenia pri oneskorenom doručení a upozornenie zákazníka o tejto udalosti***/
            Console.WriteLine("(3.4)Updating shipment delivery prices and sending notifications...");
            Console.WriteLine(ShipmentTable.LateShipNotificationAndUpdate("Ospravedlňujeme sa za meškanie vašej zásielky.", db));
            Console.WriteLine(" ");

            /***3.5 História a pohyb zásielky***/
            String Updated = ShipmentTable.HistoryAndMovement(11122, "zrusena zakaznikom", 4, db);
            Console.WriteLine("(3.5) " + Updated);