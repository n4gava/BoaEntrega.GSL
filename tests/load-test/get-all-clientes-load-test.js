import http from "k6/http";
import { sleep } from "k6";

export default function () {

    var params = {
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDM5MGU1My04NDdkLTQ1ZmQtOGJjOC0wNmQzNWMxNTk5OWQiLCJlbWFpbCI6Imd1aWxoZXJtZS5nYXZhenpvbmlAdGVzdGUuY29tIiwiUm9sZSI6IkFkbWluIiwibmJmIjoxNjMzMzkxMzU1LCJleHAiOjE2NjQ5MjczNTUsImlhdCI6MTYzMzM5MTM1NX0.EsAo8KJRbuEaZGXeMA0Jec6XhJwHYiYs6KJkoDP8b14"
        },
    };

    http.get("http://host.docker.internal:9000/cadastros/api/clientes", params);
    sleep(1);
}
