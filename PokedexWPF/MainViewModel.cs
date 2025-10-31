using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading;
using System;
using System.Linq;
using PokedexLibrary.API;
using PokedexLibrary.API.DTOs.Pokemon;
using PokedexLibrary.Calculations.Common;

namespace PokedexWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly PokeApiClient _api = new();
        private string _query = "bulbasaur";
        private Pokemon? _pokemon;
        private Uri? _artwork;
        private bool _isBusy;
        private string? _error;
        private string? _japaneseName;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

        public string Query
        {
            get => _query;
            set { _query = value; OnPropertyChanged(); }
        }

        public Pokemon? Pokemon
        {
            get => _pokemon;
            private set { _pokemon = value; OnPropertyChanged(); OnPropertyChanged(nameof(PrimaryType)); OnPropertyChanged(nameof(BaseStats)); }
        }

        public string? PrimaryType => Pokemon?.Types?.Count > 0 ? Pokemon.Types[0].Type.Name : null;
        public string? SecondaryType => Pokemon?.Types?.Count > 1 ? Pokemon.Types[1].Type.Name : null;


        public BaseStats BaseStats
        {
            get
            {
                if (Pokemon?.Stats is null)
                    return default;

                int Get(string name) => (int?)Pokemon.Stats.FirstOrDefault(s => s.StatValue.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.BaseStat ?? 0;

                return new BaseStats(
                    Get("hp"),
                    Get("attack"),
                    Get("defense"),
                    Get("special-attack"),
                    Get("special-defense"),
                    Get("speed")
                    );
            }
        }

        public Uri? Artwork
        {
            get => _artwork;
            private set { _artwork = value; OnPropertyChanged(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set { _isBusy = value; OnPropertyChanged(); }
        }

        public string? Error
        {
            get => _error;
            private set { _error = value; OnPropertyChanged(); }
        }

        public string? JapaneseName
        {
            get => _japaneseName;
            private set { _japaneseName = value; OnPropertyChanged(); }
        }

        private ICommand? _search;
        public ICommand SearchCommand => _search ??= new AsyncCommand(LoadAsync);

        private async Task LoadAsync(CancellationToken ct)
        {
            try
            {
                IsBusy = true;
                Error = null;

                Pokemon = await _api.GetPokemonAsync(Query, ct);   
                if (Pokemon is null) { Artwork = null; JapaneseName = null; return; }

                Artwork = Pokemon.Sprites?.Other?.OfficialArtwork?.FrontDefault
                          ?? Pokemon.Sprites?.FrontDefault;

                // var species = await _api.GetSpeciesAsync(Pokemon.Name, ct);
                // JapaneseName = species?.Names?.FirstOrDefault(n => 
                //     n.Language.Name.Equals("ja-Hrkt", StringComparison.OrdinalIgnoreCase))?.Name
                //     ?? species?.Names?.FirstOrDefault(n => 
                //     n.Language.Name.Equals("ja", StringComparison.OrdinalIgnoreCase))?.Name;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public sealed class AsyncCommand : ICommand
    {
        private readonly Func<CancellationToken, Task> _run;
        private bool _busy;
        public AsyncCommand(Func<CancellationToken, Task> run) => _run = run;
        public bool CanExecute(object? parameter) => !_busy;
        public event EventHandler? CanExecuteChanged;
        public async void Execute(object? parameter)
        {
            if (_busy) return;
            _busy = true; CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            try { await _run(CancellationToken.None); }
            finally { _busy = false; CanExecuteChanged?.Invoke(this, EventArgs.Empty); }
        }
    }
}
