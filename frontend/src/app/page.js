'use client'

import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";
import { getAllTrips } from "./services/trips";
import UserTripCard from "./components/usertripcard";

export default function AllTripsPage() {
    const [trips, setTrips] = useState([]);
    const router = useRouter();

    const handleFetchTrips = async () => {
        const tripsData = await getAllTrips();
        setTrips(tripsData);
    };

    useEffect(() => {
        handleFetchTrips();
    }, []); 

    return(
        <>
            <h1 className="text-3xl font-bold text-center my-5">Все поездки</h1>
            <div className="flex flex-wrap">
                {trips.map((trip) => (
                    
                    <UserTripCard 
                        key={trip.id}
                        id={trip.id}
                        title={trip.name}
                        description={trip.description}
                        startPlace={trip.route.startPlace}
                        endPlace={trip.route.endPlace}
                        userName={trip.user.name}
                    />
                ))}
            </div>
        </>
    );
}