using System;

namespace Application.Services {
  public class ParishLetter {
    public event Action ActionChange;
    //public Portal.Models.Gb.Ausgabe.Gesamt Gesamtausgabe;
    public void OnChange() => ExecuteChange();
    private void ExecuteChange() => ActionChange?.Invoke();
  }
}