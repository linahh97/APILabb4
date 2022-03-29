# APILabb4
1. get > https://localhost:44356/api/people (hämtar alla personer)
2-3. get > https://localhost:44356/api/personhobbies/1 (hämtar en specifik person och får hobby & link)
4. post > https://localhost:44356/api/personhobbies/> body > raw > json > 
{
        "hobbyId": 6,
        "personId": 1,
        "webLink": "pinterest.com/",
        "hobby": {
            "hobbyName": "Coding",
            "description": "Computer programming",
            "personHobbies": []
        },
        "person": null
} (kopplar ny hobby till person)
5. put > https://localhost:44356/api/personhobbies/11 > body > raw > json > {
        "personHobbyId": 9,
        "hobbyId": 4,
        "personId": 4,
            "webLink": "www.spotify.com/"
} (lägger till en länk)
