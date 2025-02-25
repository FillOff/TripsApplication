'use client'

import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import { deleteTrip, getTrip, updateTrip } from "@/app/services/trips";
import Map from "@/app/components/map";
import StatusText from "@/app/components/status";
import { tripModel } from "@/app/models/trip";
import { updateRoute } from "@/app/services/route";

export default function EditTripPage() {
    const router = useRouter();
    const [trip, setTrip] = useState(tripModel); 
    const id = useParams().id;
    const [selectedImage, setSelectedImage] = useState(null);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [startDateTime, setStartDateTime] = useState("");
    const [endDateTime, setEndDateTime] = useState("");
    const [startPlace, setStartPlace] = useState("");
    const [endPlace, setEndPlace] = useState("");
    const [duration, setDuration] = useState(0);
    const [length, setLength] = useState(0);

    useEffect(() => {
        handleFetchTrip();
    }, []); 

    const handleFetchTrip = async () => {
        try {
            const tripData = await getTrip(id);
            if (tripData) {
                setTrip(tripData);
                setName(tripData.name);
                setDescription(tripData.description);
                setStartPlace(tripData.route.startPlace);
                setEndPlace(tripData.route.endPlace);
                setDuration(tripData.route.duration);
                setLength(tripData.route.length);
                setStartDateTime(tripData.startDateTime);
                setEndDateTime(tripData.endDateTime);
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

    return (
        <>
            <div>
                <form className="mx-auto p-4 space-y-4">
                    <div>
                        <label htmlFor="name" className="block text-sm font-medium text-gray-700">Название</label>
                        <input
                            type="text"
                            id="name"
                            defaultValue={name}
                            onChange={(e) => {
                                setName(e.target.value);
                            }}
                            className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                            required
                        />
                    </div>

                    <div>
                        <label htmlFor="description" className="block text-sm font-medium text-gray-700">Описание поездки</label>
                        <textarea
                            id="description"
                            defaultValue={description}
                            onChange={(e) => {
                                setDescription(e.target.value);
                            }}
                            className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                        />
                    </div>

                    <div className='space-y-4'>
                        <div>
                            <label htmlFor="startPlace" className="block text-sm font-medium text-gray-700">Начало пути</label>
                            <input
                                type="text"
                                id="startPlace"
                                defaultValue={startPlace}
                                className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                                required
                            />
                        </div>
                        <div>
                            <label htmlFor="endPlace" className="block text-sm font-medium text-gray-700">Конец пути</label>
                            <input
                                type="text"
                                id="endPlace"
                                defaultValue={endPlace}
                                className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                                required
                            />
                        </div>
                        <button
                            className="w-full mt-2 py-2 px-4 bg-gray-700 text-white font-medium rounded-md focus:bg-gray-500"
                            onClick={() => {
                                setStartPlace(document.getElementById('startPlace').value);
                                setEndPlace(document.getElementById('endPlace').value);
                            }}
    
                            type='button'
                        >
                            Изменить маршрут
                        </button>
                        <Map 
                            startPlace={startPlace}
                            endPlace={endPlace}
                            setLength={setLength}
                            setDuration={setDuration}
                        />
                    </div>

                    <div>
                        <label htmlFor="startDateTime" className="block text-sm font-medium text-gray-700">Дата и время начала пути</label>
                        <input
                        type="datetime-local"
                        id="startDateTime"
                        value={startDateTime}
                        onChange={(e) => {
                            setStartDateTime(e.target.value);
                        }}
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                        required
                        />
                    </div>

                    <div>
                        <label htmlFor="endDateTime" className="block text-sm font-medium text-gray-700">Дата и время конца пути</label>
                        <input
                        type="datetime-local"
                        id="endDateTime"
                        value={endDateTime}
                        onChange={(e) => {
                            setEndDateTime(e.target.value);
                        }}
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                        required
                        />
                    </div>

                    {divImages()}

                    <div className="my-5">
                        <a 
                            className="bg-yellow-500 hover:bg-yellow-700 cursor-pointer text-white font-bold py-2 px-4 rounded ml-4 my-5"
                            onClick={async () => {
                                
                                router.push(`/trips/${id}`);
                            }}
                            >
                            Отменить изменения
                        </a>
                        <a 
                            className="bg-green-500 hover:bg-green-700 cursor-pointer text-white font-bold py-2 px-4 rounded ml-4 my-5"
                            onClick={async () => {
                                console.log(await updateRoute(trip.route.id, startPlace, endPlace, Math.floor(duration), length));
                                await updateTrip(id, name, description, startDateTime, endDateTime, trip.relativeDateTime, trip.tripStatus);
                                router.push("/trips");
                            }}
                        >
                            Сохранить изменения
                        </a>
                    </div>
                </form>

            </div>
            
            
        </>
    );
}