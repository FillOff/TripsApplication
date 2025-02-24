'use client'

import { useEffect, useState } from "react";
import { getTrips } from "../services/trips";
import TripCard from "../components/tripcard";

export default function TripsPage() {
    const [trips, setTrips] = useState([]);
    
    const handleFetchTrips = async () => {
        try {
            const tripsData = await getTrips();
            setTrips(tripsData);
        } catch (error) {
            console.error("Ошибка при аутентификации или получении поездок:", error);
        }
    };

    useEffect(() => {
        handleFetchTrips();
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