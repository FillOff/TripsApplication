'use client'

import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { getTrip } from "@/app/services/trips";
import { tripModel } from "@/app/models/trip";
import Map from "@/app/components/map";
import { tripStatus } from "@/app/models/tripStatus";

export default function TripIdPage() {
    const [trip, setTrip] = useState(tripModel);
    const id = useParams().id;

    const handleFetchTrip = async () => {
        try {
            const tripData = await getTrip(id);
            setTrip(tripData);
        } catch (error) {
            console.error("Ошибка при аутентификации или получении поездок:", error);
        }
    };

    useEffect(() => {
        handleFetchTrip();
    }, []); 

    return (
        <>
            <h1 className="text-3xl font-bold text-center my-5">Поездка "{trip.name}"</h1>
            <div className="container">
                <div className="mx-auto bg-white shadow-lg rounded-lg overflow-hidden my-4">
                    <div className="px-6 py-4">
                        <h2 className="text-2xl font-bold text-gray-800">{trip.name}</h2>
                        <p className="text-gray-600 mt-2">{trip.description}</p>
                    </div>

                    <div className="px-6 py-4">
                        <p className="text-gray-700">
                        <span className="font-semibold">Start:</span> {new Date(trip.startDateTime).toLocaleString()}
                        </p>
                        <p className="text-gray-700">
                        <span className="font-semibold">End:</span> {new Date(trip.endDateTime).toLocaleString()}
                        </p>
                    </div>

                    <div className="px-6 py-4">
                        <span className="inline-block bg-blue-200 text-blue-800 text-sm font-semibold px-3 py-1 rounded-full">
                        Status: {tripStatus[trip.tripStatus]}
                        </span>
                    </div>

                    <div className="px-6 py-4">
                        <h3 className="text-xl font-semibold text-gray-800">Route Details</h3>
                        <p className="text-gray-700">
                        <span className="font-semibold">From:</span> {trip.route.startPlace}
                        </p>
                        <p className="text-gray-700">
                        <span className="font-semibold">To:</span> {trip.route.endPlace}
                        </p>
                        <p className="text-gray-700">
                        <span className="font-semibold">Distance:</span> {trip.route.length} km
                        </p>
                        <p className="text-gray-700">
                        <span className="font-semibold">Duration:</span> {trip.route.duration}
                        </p>
                        <Map 
                            startPlace={trip.route.startPlace}
                            endPlace={trip.route.endPlace}
                        />
                    </div>

                    <div className="px-6 py-4">
                        <h3 className="text-xl font-semibold text-gray-800">Comments</h3>
                        {trip.comments.map((comment) => (
                        <div key={comment.id} className="mt-2 p-2 bg-gray-100 rounded-lg">
                            <p className="text-gray-700">{comment.content}</p>
                        </div>
                        ))}
                    </div>

                    <div className="px-6 py-4">
                        <h3 className="text-xl font-semibold text-gray-800">Images</h3>
                        <div className="flex flex-wrap gap-2 mt-2">
                        {trip.images.map((image) => (
                            <img
                            key={image.id}
                            src={image.url}
                            alt="Trip"
                            className="w-24 h-24 object-cover rounded-lg"
                            />
                        ))}
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}