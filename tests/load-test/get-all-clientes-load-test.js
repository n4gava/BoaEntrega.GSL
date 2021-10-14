import http from "k6/http";
import { sleep } from "k6";

export default function () {

    var params = {
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzNzJhYWNkYy0zMTFjLTQwZTgtOTkwZi1lYTVlZWI2MDFiZDAiLCJlbWFpbCI6InRlc3RlQHRlc3RlLmNvbSIsInVpZCI6IjM3MmFhY2RjLTMxMWMtNDBlOC05OTBmLWVhNWVlYjYwMWJkMCIsIlJvbGUiOlsiQWRtaW4iLCJVc3VhcmlvIl0sIm5iZiI6MTYzNDE2MjE1NiwiZXhwIjoxNjY1Njk4MTU1LCJpYXQiOjE2MzQxNjIxNTZ9.bd6dgCjcBoziB9_9Z8mmYEPspTsTZk6qBgswqJ_pu2I"
        },
    };

    http.get("http://host.docker.internal:9000/cadastros/api/clientes", params);
    sleep(1);
}
