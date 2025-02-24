'use client'

import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import { deleteTrip, getTrip, updateTrip } from "@/app/services/trips";
import Map from "@/app/components/map";
import StatusText from "@/app/components/status";
import { tripModel } from "@/app/models/trip";

export default function TripIdPage() {
    const router = useRouter();
    const [trip, setTrip] = useState(tripModel); 
    const [duration, setDuration] = useState(0);
    const [length, setLength] = useState(0);
    const id = useParams().id;
    const [selectedImage, setSelectedImage] = useState(null);

    useEffect(() => {
        handleFetchTrip();
    }, []); 

    const handleFetchTrip = async () => {
        try {
            const tripData = await getTrip(id);
            if (tripData) {
                setTrip(tripData);
            } else {
                console.error("Полученные данные о поездке пусты");
            }
        } catch (error) {
            console.error("Ошибка при получении поездки:", error);
        }
    };

    function divImages() {
        if (trip && trip.images && trip.images.length > 0) { 
            return (
                <div className="px-6">
                    <h3 className="text-xl font-semibold text-gray-800">Картинки</h3>
                    <div className="flex overflow-x-auto gap-2 mt-2">
                        {trip.images.map((image) => 
                            image.url ? ( 
                                <img
                                    key={image.id}
                                    src={image.url}
                                    alt="Trip"
                                    className="w-28 h-28 object-cover rounded-lg cursor-pointer"
                                    onClick={() => setSelectedImage(image.url)}
                                />
                            ) : null
                        )}
                    </div>
                    {selectedImage && (
                        <div
                            className="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-[100]"
                            onClick={() => setSelectedImage(null)}
                        >
                            <img
                                src={selectedImage}
                                alt="Fullscreen Trip"
                                className="max-w-full max-h-full"
                            />
                        </div>
                    )}
                </div>
            );
        }
    }

    function divComments() {
        if (trip && trip.images && trip.comments.length > 0) {
            return (
                <div className="px-6 py-4">
                    <h3 className="text-xl font-semibold text-gray-800">Comments</h3>
                    {trip.comments.map((comment) => (
                    <div key={comment.id} className="mt-2 p-2 bg-gray-100">
                        <p className="text-gray-700">{comment.content}</p>
                    </div>
                    ))}
                </div>
            );
        }
    }

    return (
        <>
            <h1 className="text-3xl font-bold text-center my-5">Поездка "{trip.name}"</h1>
            <div>
                <div className="mx-auto bg-white overflow-hidden my-4">
                    <div className="px-6 py-4">
                        <p className="text-gray-700 mt-2">
                        <b>Описание: </b> 
                            {trip.description}
                        </p>
                        <p className="text-gray-700">
                            <b>Время начала: </b> 
                            {new Date(trip.startDateTime).toLocaleString()}
                        </p>
                        <p className="text-gray-700">
                            <b>Время конца: </b> 
                            {new Date(trip.endDateTime).toLocaleString()}
                        </p>

                        <StatusText 
                            tripStatusNumber={trip.tripStatus}
                        />

                        <p className="text-gray-700">
                            <b>Откуда: </b> 
                            {trip.route.startPlace}
                        </p>
                        <p className="text-gray-700">
                            <b>Куда: </b> 
                            {trip.route.endPlace}
                        </p>
                        <p className="text-gray-700">
                            <b>Дистанция: </b> 
                            {trip.route.length} km
                        </p>
                        <p className="text-gray-700">
                            <b>Длительность: </b>
                            {trip.route.duration}
                        </p>
                        <Map 
                            startPlace={trip.route.startPlace}
                            endPlace={trip.route.endPlace}
                            setLength={setLength}
                            setDuration={setDuration}
                        />
                    </div>

                    {divImages()}

                    {divComments()}

                </div>

            </div>
            <div className="my-5">
                <a 
                    className="bg-yellow-500 hover:bg-yellow-700 cursor-pointer text-white font-bold py-2 px-4 rounded ml-4 my-5"
                    onClick={async () => {
                        await updateTrip(id, trip.name, trip.description, String(trip.startDateTime), String(trip.endDateTime), trip.relativeDateTime, 3);
                        router.push("/trips");
                    }}
                    >
                    Отменить поездку
                </a>
                <a 
                    className="bg-red-500 hover:bg-red-700 cursor-pointer text-white font-bold py-2 px-4 rounded ml-4 my-5"
                    onClick={async () => {
                        await deleteTrip(id);
                        router.push("/trips");
                    }}
                >
                    Удалить поездку
                </a>
            </div>
        </>
    );
}