var currentPlanet = "Earth"
var jsonDataSource = new XMLHttpRequest();
var url = "/Data/getPrices";

jsonDataSource.onreadystatechange = function () {
    if (jsonDataSource.readyState == 4 && jsonDataSource.status == 200) {
        var jsonData = JSON.parse(jsonDataSource.responseText);
        populatePrices(jsonData);
    }
}

function populatePrices(jsonData) {
    var priceStatus = "";
    var locationStatus = "<h2>" + currentPlanet + "</h2><h3>Change Location</h3>";
    priceStatus += "<h3>Current Price</h3>";
    priceStatus += '<div class="priceListing">Air: ' + jsonData.airPrice + '</div>';
    priceStatus += '<div class="priceListing">Power: ' + jsonData.powerPrice + ' </div>';
    priceStatus += '<div class="priceListing">Water: ' + jsonData.waterPrice + '</div>';
    priceStatus += '<div class="priceListing">Food: ' + jsonData.foodPrice + '</div>';
    priceStatus += '<div class="priceListing">Fuel: ' + jsonData.fuelPrice + '</div>';
    priceStatus += '<div class="priceListing">Weapons: ' + jsonData.weaponPrice + '</div>';
    priceStatus += '<div class="priceListing">Metal: ' + jsonData.metalPrice + '</div>';
    priceStatus += '<div class="priceListing">Refugees: ' + jsonData.refugees + '</div>';
    priceStatus += '<div class="priceListing">Research: ' + jsonData.research + '</div>';
    document.getElementById("priceStatus").innerHTML = priceStatus;
    var nearByLocations = jsonData.nearbyLocations;
    for (var i = 0; i < nearByLocations.length; i++) {
        if (nearByLocations[i] != currentPlanet) {
            locationStatus += '<a href="#" onclick="travel(\'' + nearByLocations[i] + '\')"> Travel to ' + nearByLocations[i] + '</a>'
        }
    }
    document.getElementById("locationStatus").innerHTML = locationStatus;
}


function travel(location) {
    currentPlanet = location;
    jsonDataSource.open("GET", url, true);
    jsonDataSource.send();
}

jsonDataSource.open("GET", url, true);
jsonDataSource.send();

