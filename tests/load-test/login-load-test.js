import http from "k6/http";
import { sleep } from "k6";

export default function () {
    var payload = JSON.stringify({
        email: "teste@teste.com",
        password: "123456",
    });

    var params = {
        headers: {
            "Content-Type": "application/json",
        },
    };

    http.post("http://host.docker.internal:9000/identidade/api/users/login", payload, params);
    sleep(1);
}
