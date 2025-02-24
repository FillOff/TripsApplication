'use client'

import { useEffect, useState } from "react";
import { getTrips } from "../services/trips";
import TripCard from "../components/tripcard";
import { useRouter } from "next/navigation";

export default function TripsPage() {
    const [trips, setTrips] = useState([]);
    const router = useRouter();
    
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
        <div className="w-full h-full px-5">
            <h1 className="text-3xl font-bold text-center my-5">Список поездок</h1>
            <a 
                className="bg-green-500 hover:bg-green-700 cursor-pointer text-white font-bold py-2 px-4 rounded ml-4"
                onClick={() => {
                    router.push("/trips/new");
                }}
            >
                Создать новую поездку
            </a>
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
        </div>
    );
}