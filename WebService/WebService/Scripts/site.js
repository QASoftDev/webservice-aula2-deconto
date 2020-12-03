// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

//Busca Pokemon
    var nomePokemon;
    var numeroPokemon;
    var urlImgPokemon;

    let txtPesquisaPokemon = document.getElementById("buscarPokemon");

    let txtNomePokemonPreferido = document.getElementById("nomePokemonPreferido");
    let txtNumeroPokemonPreferido = document.getElementById("numeroPokemonPreferido");
    let txtUrlImgPokemonPreferido = document.getElementById("urlImgPokemonPreferido");

    function BuscarPokemon() {

        let pokemon = txtPesquisaPokemon.value;

        let url = `https://pokeapi.co/api/v2/pokemon/${pokemon}`;
        fetch(url)
            .then(
                function (response) {
                    response.json()
                        .then(function (data) {
                            //console.log(data)
                            //console.log(data.name)
                            //console.log(data.id)
                            //console.log(data.sprites.front_default)
                            txtNomePokemonPreferido.value = data.name;
                            txtNumeroPokemonPreferido.value = data.id;
                            txtUrlImgPokemonPreferido.value = data.sprites.front_default;
                            nomePokemon = data.name;
                            numeroPokemon = data.id;
                            urlImgPokemon = data.sprites.front_default;
                            document.getElementById('qr_img').src = urlImgPokemon;
                            console.log(nomePokemon)
                            console.log(numeroPokemon)
                            console.log(urlImgPokemon)
                            console.log(txtNomePokemonPreferido.value)

                        })
                })
            .catch(error => console.log(error));
    }