PELNO / NUOSTOLIO SKAIČIAVIMAS

Užduotis: iš duotų duomenų X dienai Y klientui suskaičiuoti realizuotą pelną/nuostolį FIFO metodu
(https://www.investopedia.com/terms/f/fifo.asp) kiekvienai turimai akcijai (Security).
Prielaidos:
* console aplikacija;
* duomenų faile pirma eilutė nurodo laukų eiliškumą (pavadinimas atitinkantis Trades klasėje nurodytus
laukus), nuo antros eilutės – duomenys;
* duomenys faile atskirti ; simboliu;
* paduodami parametrai Client, Date, duomenų failo kelias (per console line);
* pirkimo metu mokestis didina savikainą, pardavimo metu mažina pelną.
Reikalavimai:
* Nuskaityti duomenų failą (data.csv) į Trades listą atsižvelgiant į tai, kad stulpelių eiliškumas gali skirtis;
* Duotam Client ir Date suskaičiuoti pelną/nuostolį keikvienam Security, rezultatą atvaizduoti lentele
(atitinkmai out.txt).
Trades klasė:
public class Trades
{
public int TradeId { get; set; }
public string Type { get; set; } //BUY or SELL
public DateTime Date { get; set; }
public string Client { get; set; }
public string Security { get; set; }
public int Amount { get; set; }
public decimal Price { get; set; }
public decimal Fee { get; set; }
}
data.csv pavyzdys:
TradeId;Type;Date;Client;Security;Amount;Price;Fee
1;BUY;2024-01-02;Jonas;TSLA;10;35,25;17,62
2;BUY;2024-01-02;Rūta;TSLA;11;34,12;18,76
3;BUY;2024-01-01;Jonas;APPL;100;1,25;6,25
4;BUY;2024-01-04;Jonas;TSLA;5;38,78;9,69
5;BUY;2024-01-02;Jonas;APPL;20;1,2;1,2
6;SELL;2024-01-05;Jonas;APPL;50;1,25;3,12
7;SELL;2024-01-04;Rūta;TSLA;110;37,01;203,55
8;SELL;2024-01-06;Jonas;APPL;20;1,5;1,5
9;BUY;2024-01-03;Jonas;TSLA;5;41,11;10,27
10;BUY;2024-01-04;Rūta;APPL;2;0,8;0,08
11;SELL;2024-01-06;Jonas;TSLA;18;40;36
12;SELL;2024-01-02;Rūta;APPL;1;1,25;0,06
13;SELL;2024-01-03;Rūta;APPL;8;1,5;0,6
14;BUY;2024-01-01;Rūta;TSLA;100;35,11;175,55
15;BUY;2024-01-03;Rūta;TSLA;9;35;15,75
16;SELL;2024-01-03;Jonas;APPL;80;1,35;5,4
17;BUY;2024-01-05;Rūta;TSLA;5;40;10
18;BUY;2024-01-04;Jonas;APPL;30;1,3;1,95
19;SELL;2024-01-06;Rūta;TSLA;10;31,11;15,55
20;SELL;2024-01-05;Rūta;APPL;3;2,2;0,33
21;BUY;2024-01-01;Rūta;APPL;10;1,25;0,62
