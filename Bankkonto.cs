using System;

public class Bankkonto
{
    // Private Felder
    private string kontoinhaber;
    private double kontostand;
    private string kontonummer;

    // Öffentliche Eigenschaften (Read-Only)
    public string Kontoinhaber
    {
        get { return kontoinhaber; }
    }

    public double Kontostand
    {
        get { return kontostand; }
    }

    public string Kontonummer
    {
        get { return kontonummer; }
    }

    // Konstruktor
    public Bankkonto(string kontoinhaber, string kontonummer, double startkontostand = 0)
    {
        this.kontoinhaber = kontoinhaber;
        this.kontonummer = kontonummer;
        this.kontostand = startkontostand >= 0 ? startkontostand : 0;
    }

    // Methode: Einzahlen
    public void Einzahlen(double betrag)
    {
        if (betrag <= 0)
        {
            Console.WriteLine($"❌ Fehler: Der Einzahlungsbetrag muss positiv sein! (eingegeben: {betrag}€)");
            return;
        }

        kontostand += betrag;
        Console.WriteLine($"✓ {betrag}€ eingezahlt. Neuer Kontostand: {kontostand:F2}€");
    }

    // Methode: Abheben
    public void Abheben(double betrag)
    {
        if (betrag <= 0)
        {
            Console.WriteLine($"❌ Fehler: Der Abhebungsbetrag muss positiv sein! (eingegeben: {betrag}€)");
            return;
        }

        if (betrag > kontostand)
        {
            Console.WriteLine($"❌ Fehler: Unzureichende Deckung! Kontostand: {kontostand:F2}€, angefordert: {betrag}€");
            return;
        }

        kontostand -= betrag;
        Console.WriteLine($"✓ {betrag}€ abgehoben. Neuer Kontostand: {kontostand:F2}€");
    }

    // Methode: Kontoauszug drucken
    public void KontoauszugDrucken()
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("                    KONTOAUSZUG");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine($"Kontoinhaber:   {kontoinhaber}");
        Console.WriteLine($"Kontonummer:    {kontonummer}");
        Console.WriteLine($"Kontostand:     {kontostand:F2}€");
        Console.WriteLine(new string('=', 50) + "\n");
    }
}
