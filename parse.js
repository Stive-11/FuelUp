var serviceStr = "[{"ID":1,"Service":"\"24/7\"","Code":1},{"ID":2,"Service":"AdBlue","Code":2},{"ID":3,"Service":"Автоматическая мойка","Code":4},{"ID":4,"Service":"Ручная мойка","Code":8},{"ID":5,"Service":"Туалет","Code":16},{"ID":6,"Service":"Подкачка шин","Code":32},{"ID":7,"Service":"Пылесос","Code":64},{"ID":8,"Service":"Терминал оплаты","Code":128},{"ID":9,"Service":"Парковка","Code":256},{"ID":10,"Service":"Реализация шин","Code":512},{"ID":11,"Service":"Аренда прицепов","Code":1024},{"ID":12,"Service":"Садовый центр","Code":2048},{"ID":13,"Service":"Банкомат","Code":4096},{"ID":14,"Service":"Обмен валюты","Code":8192},{"ID":15,"Service":"Шиномонтаж","Code":16384},{"ID":16,"Service":"Колонка отпуска жидкости в стеклоомыватель","Code":32768},{"ID":17,"Service":"Wi-Fi","Code":65536},{"ID":18,"Service":"Таксофон","Code":131072},{"ID":19,"Service":"Ксерокопия","Code":262144},{"ID":20,"Service":"Страхование","Code":524288},{"ID":21,"Service":"Туалет для инвалидов","Code":1048576},{"ID":22,"Service":"Прокат велосипедов","Code":2097152},{"ID":23,"Service":"Магазин","Code":4194304},{"ID":24,"Service":"Кафе","Code":8388608},{"ID":25,"Service":"Отель","Code":16777216},{"ID":26,"Service":"BelToll","Code":33554432},{"ID":27,"Service":"СТО","Code":67108864},{"ID":28,"Service":"Душ для посетителей","Code":134217728}]";
var services = JSON.parse(serviceStr);

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

function createCod (arrayId){
	var cod = arrayId.reduce(function(id, sum) {return sum + getService(id).Code;}, 0);
}

function getService (id) {
	for (var i = services.length - 1; i >= 0; i--) {
		if (services[i].ID == id) return services[i];
	}
}

function getServiceNames (arrayId){
	return arrayId.map(getService(id).Service);	
}