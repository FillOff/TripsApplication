export const getTrips = async () => {
    const response = await fetch("http://localhost:8080/api/Trips", {
        mode: 'no-cors',
        method: "GET",
        credentials: 'include'
    });

    const data = await response.json();
    return data;
}

export const login = async () => {
    const url = 'http://localhost:8080/api/auth/login'; // Замените на ваш URL API

    // Данные для отправки
    const data = {
        email: "123",
        password: "123"
    };

    // Настройки для fetch
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    });
}