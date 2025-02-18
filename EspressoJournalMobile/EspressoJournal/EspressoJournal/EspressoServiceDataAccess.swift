import Foundation

// Grinder API
func getGrinders(completion: @escaping (Result<String, Error>) -> Void) {

    // Build API request
    let url: URL = URL(string: "http://localhost:5100/grinder")!

    // Make API call
    let task: URLSessionDataTask = URLSession.shared.dataTask(with: url) { data, response, error in
        // Check for errors
        if let error: any Error = error {
            completion(.failure(error))
            return
        }
        guard let data: Data = data else {
            completion(.failure(URLError(.badServerResponse)))
            return
        }
        guard let grinders: String = String(data: data, encoding: .utf8) else {
            completion(.failure(URLError(.badServerResponse)))
            return
        }
        completion(.success(grinders))
    }
    task.resume()
}
