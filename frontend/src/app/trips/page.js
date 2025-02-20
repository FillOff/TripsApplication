'use client'

import { useEffect, useState } from "react";
import { getTrips, login } from "../services/trips";
import TripCard from "../components/tripcard";

export default function TripsPage() {
    const [trips, setTrips] = useState([]);

    useEffect(() => {
        const handleLoginAndFetchTrips = async () => {
            try {
                const loginResponse = await login();
                console.log("Login successful:", loginResponse);

                const tripsData = await getTrips(loginResponse);
                setTrips(tripsData);
            } catch (error) {
                console.error("Ошибка при аутентификации или получении поездок:", error);
            }
        };

        handleLoginAndFetchTrips();

    }, []); 

    return (
        <>
            <h1 className="text-3xl font-bold text-center my-5">Список поездок</h1>
            <div className="flex">
                {trips.map((trip) => (
                    <TripCard 
                        key={trip.id}
                        id={trip.id}
                        title={trip.name}
                        description={trip.description}
                        startDate={trip.startDateTime}
                        endDate={trip.endDateTime}
                        tripStatusNumber={trip.tripStatus}
                    />
                ))}
            </div>
        </>
    );
}