'use client'

import { useEffect, useState } from "react";
import { getHistoryTrips } from "../services/trips";
import TripCard from "../components/tripcard";

export default function HistoryPage() {
    const [trips, setTrips] = useState([]);
    
    const handleFetchHistoryTrips = async () => {
        try {
            const tripsData = await getHistoryTrips();
            setTrips(tripsData);
        } catch (error) {
            console.error("Ошибка при аутентификации или получении поездок:", error);
        }
    };

    useEffect(() => {
        handleFetchHistoryTrips();
    }, []); 

    return (
        <>
            <h1 className="text-3xl font-bold text-center my-5">История поездок</h1>
            <div className="lex flex-wrap">
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