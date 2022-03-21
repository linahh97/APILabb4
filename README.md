# APILabb4
1. get > https://localhost:44356/api/people (hämtar alla personer)
2-3. get > https://localhost:44356/api/personhobbies/1 (hämtar en specifik person och får hobby & link)
4. post > https://localhost:44356/api/personhobbies/> body > raw > json > {
    "hobbyId": 2,
        "personId": 1,
                "webLink": "www.hajper.com/sv"
} (kopplar ny hobby till person)
5. put > https://localhost:44356/api/personhobbies/11 > body > raw > json > {
        "personHobbyId": 11,
        "hobbyId": 2,
        "personId": 4,
            "webLink": "www.bet365.com/"
} (lägger till en länk)
