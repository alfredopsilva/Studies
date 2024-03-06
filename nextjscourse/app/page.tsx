import Banner from "../components/banner.client"


export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <Banner buttonText="Discover Coffees near by" handleOnClick={() => { console.log("Hello Button") }} />
    </main>
  );
}
