# shake-poke-api

## The task

There are successful brands who have managed to stay relevant for more than a decade without innovating too much.

Some of our colleagues have young children and we’d like to offer them a fresh perspective at the world of Pokemon: what if the description of each Pokemon were to be written using Shakespeare’s style?

We would like you to develop a REST API that, given a Pokemon name, returns its Shakespearean description.

## API Requirements 

GET endpoint: /pokemon/<pokemon name>

Usage example (using httpie):
http http://localhost:5000/pokemon/charizard

Output format:
{
  "name": "charizard",
  "description": "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous heat yond 't melts aught. However, 't nev'r turns its fiery breath on any opponent weaker than itself."
}



## Guidelines:
* Feel free to use any programming language, framework and library you want. 
* Make it concise, readable and correct.
* Test it!
* Useful APIs:
  * Shakespeare translator: https://funtranslations.com/api/shakespeare
  * PokéAPI: https://pokeapi.co/docs/v2.html/
  * The description required in this task is listed as “flavor_text_entries” in the Pokemon Species resource ( https://pokeapi.co/docs/v2.html/#pokemon-species ).

You can get there following the resource address provided in the “species” field by the Pokemon resource ( https://pokeapi.co/docs/v2.html/#pokemon )

## Running the solution

* The solution has been written in C# using the .Net Core 2.1 framework
* To run, navigate to the directory ~\shake-poke-api\ShakePokeAPI\ on command line
* Enter 'dotnet run'
* The program will now be running on http://localhost:5000/pokemon/{pokemonname}

## Running in docker container

* Navigate to directory ~\shake-poke-api\ on command line. This is the folder containing the Dockerfile
* Enter 'docker build -t aspnetapp .'
* Enter 'docker run -d -p 8080:80 --name myapp aspnetapp'
* The application will now be running on http://localhost:8080/pokemon/{pokemonname}
