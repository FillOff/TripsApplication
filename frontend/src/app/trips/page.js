'use client'

import { useEffect, useState } from "react";
import { getTrips, login } from "../services/trips";

export default function TripsPage() {
    const [trips, setTrips] = useState([]);

    useEffect(() => {
        const handleLoginAndFetchTrips = async () => {
            try {
                // Call the exported login function
                const loginResponse = await login();
                console.log("Login successful:", loginResponse);

                // Fetch trips after login
                const tripsData = await getTrips(loginResponse);
                setTrips(tripsData); // Set the trips data in state
            } catch (error) {
                console.error("Ошибка при аутентификации или получении поездок:", error);
            }
        };

        handleLoginAndFetchTrips(); // Call the renamed function

    }, []); // Пустой массив зависимостей для выполнения только один раз

    return (
        <div>
            <h1>Список поездок</h1>
            <ul>
                {trips.map((trip, index) => (
                    <li key={index}>{trip.id}</li> // Отображаем поездки
                ))}
            </ul>
        </div>
    );
}