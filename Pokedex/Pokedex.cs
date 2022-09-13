using Newtonsoft.Json;
using PokeAPI.Models;
using System.Diagnostics;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        internal PokeApiHandler ApiHandler { get; set; }
        internal RestSharpHandler RestSharpHandler { get; set; }
        internal List<string> NameList { get; set; }

        public Pokedex()
        {
            InitializeComponent();

            var apiProcess = Process.Start(@"..\..\..\..\PokeAPI\bin\Debug\net6.0\PokeApi.exe");

            ApiHandler = new PokeApiHandler();
            RestSharpHandler = new("https://localhost:5001/api/pokemon/");

            NameList = GetLocalPokemon();

            textBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(NameList.ToArray());
            textBoxSearch.AutoCompleteCustomSource = autoComplete;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
                UpdatePokemon(textBoxSearch.Text.ToLower());
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text) && e.KeyValue == (char)Keys.Return)
            {
                UpdatePokemon(textBoxSearch.Text.ToLower());
            }

        }

        private List<string> GetLocalPokemon()
        {
            var nameList = new List<string>();

            try
            {
                var response = RestSharpHandler.RequestRestSharp("", "", RestSharp.Method.Get);

                var result = new List<Pokemon>();
                var pokeList = new List<string>();

                if (!string.IsNullOrWhiteSpace(response.Content))
                    result = JsonConvert.DeserializeObject<List<Pokemon>>(response.Content);

                if (result != null)
                {
                    foreach (var pokemon in result)
                    {
                        pokeList.Add(pokemon.ToString());
                        nameList.Add(pokemon.Name);
                    }
                }

                listBoxPokemon.DataSource = pokeList;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not get local pokemon list\n{ex.Message}");
            }

            return nameList;
        }

        private void UpdatePokemon(string name)
        {
            Pokemon? pokemon = new();

            try
            {
                buttonSearch.Enabled = false;

                pokemon = ApiHandler.GetPokemon(name);

                if (pokemon != null)
                {
                    labelName.Text = Capitalize(pokemon.Name);

                    pictureBoxSprite.SizeMode = PictureBoxSizeMode.Zoom;
                    if (pokemon.Sprites != null && pokemon.Sprites.Other != null && pokemon.Sprites.Other.OfficialArtwork != null)
                        pictureBoxSprite.ImageLocation = pokemon.Sprites.Other.OfficialArtwork.FrontDefault;

                    string types = string.Empty;
                    if (pokemon.Types != null)
                    {
                        foreach (var type in pokemon.Types)
                        {
                            if (type.TypeName != null)
                            {
                                if (type.Slot == 1)
                                {
                                    types += Capitalize(type.TypeName.Name);
                                }
                                else
                                {
                                    types += ", " + Capitalize(type.TypeName.Name);
                                }
                            }
                        }
                        labelTypeName.Text = types;
                    }
                }

                buttonSearch.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show($"Could not find pokemon: {textBoxSearch.Text}");
            }
        }

        private string Capitalize(string text)
        {
            return text[..1].ToUpper() + text[1..];
        }

        private void listBoxPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NameList != null)
            {
                string name = NameList[listBoxPokemon.SelectedIndex];
                UpdatePokemon(name);
            }
        }
    }
}
