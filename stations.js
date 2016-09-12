
var stationsString = "[{"name":"АЗС Галлон39","coordinates":{"latitude":52.0742,"longitude":23.7357},"codFuels":0,"codServices":0,"operatorName":null},{"name":"Мойка ООО ЮрАнГрупп","coordinates":{"latitude":53.9067,"longitude":27.4911},"codFuels":0,"codServices":4,"operatorName":null},{"name":"Универсам Полесье","coordinates":{"latitude":53.8684999999999,"longitude":27.5993},"codFuels":0,"codServices":0,"operatorName":null},{"name":"Универсам Европейский","coordinates":{"latitude":53.9312,"longitude":27.6357},"codFuels":0,"codServices":256,"operatorName":null},{"name":"Универсам Престон-маркет","coordinates":{"latitude":53.9168,"longitude":27.5606},"codFuels":0,"codServices":0,"operatorName":null},{"name":"СТО \"Автосеть\"","coordinates":{"latitude":53.874,"longitude":27.4993},"codFuels":0,"codServices":16640,"operatorName":null}]; 
var jsonString = stationsString.Replace(/null/g,"");
var stations = JSON.parse(jsonString);	



function getStations (cod){
	var stationsWithCod = [];
	for (var i=0; i<stations.length; i++) {
		if (isStationHasServices(cod, stations[i])){
			stationsWithCod.push(stations[i]);
		}
	}
	return stationsWithCod;
}

function isStationHasServices (cod, station){
	var services = station.codServices;
	if (cod == 0) return true;
	if (services == 0) return false;
	var array1 = parse(cod);
	var array2 = parse(services);
	var countEquals = 0;
	var countEqualsMax = Math.min(array1.length, array2.length);
	if (array1.length < array2.length){
		countEquals =getCountEquals (array1, array2);
	} else {
		countEquals =getCountEquals (array2, array1);
	}
	return (countEquals == countEqualsMax);
}


function getCountEquals (array1, array2){
	var equalsCount = 0;
	for (var i = array1.length - 1; i >= 0; i--) {
		if (find(array2, array1[i]) !=-1)
			equalsCount ++;
	}
	return equalsCount;
}


function parse (cod){
	var codArray = [];
	var currentCod = 134217728;
	for (var i = 28; i > 0; i--) {
		if (cod >= currentCod){
			codArray.push(i);
			cod -= currentCod;
			currentCod = currentCod / 2;
		}	
	}	
	return codArray;
}